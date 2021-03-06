﻿using MediatR;
using Quotation.Domain.Aggregates.CurrencyAgg.Commands;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Seedwork;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Handlers {
    public class CurrencyCommandHandler : CommandHandler<Currency>,
        IRequestHandler<CreateCurrencyCommand, CommandResult<Currency>>,
        IRequestHandler<UpdateCurrencyCommand, CommandResult<Currency>> {


        private readonly ICurrencyRepository currencyRepository;
        

        public CurrencyCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork) : base(unitOfWork) {
            this.currencyRepository = currencyRepository;
            
        }

        public async Task<CommandResult<Currency>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken) {

            var currency = await currencyRepository.FindOneAsync(p => p.IsoCode.Equals(request.CurrencyIso.ToLower()));

            if (currency != null)
                return CommandResult<Currency>.Fail(currency, "IsoCode already exists");

            currency = new Currency(request.Name, request.CurrencyIso);

            await currencyRepository.Add(currency);
         
            PublishEvents(currency);
            return CommandResult<Currency>.Success(currency);
        }


        public async Task<CommandResult<Currency>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken) {

            var currency = await currencyRepository.FindOneAsync(p => p.IsoCode.Equals(request.CurrencyIso.ToLower()));

            if (currency == null)
                return CommandResult<Currency>.Fail(currency, "IsoCode not exist");

            currency.Update(request.Name);
            currencyRepository.Update(currency);
          
            PublishEvents(currency);

            return CommandResult<Currency>.Success(currency);
        }
    }
}
