﻿using System;

namespace Quotation.Application.Models {
    public class CreateCorrelationPairResponse:BaseResponse {
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public decimal Coefficient { get; set; }
        public DateTime QuotationDate { get; set; }

    }
}
