﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quotation.Infra.Data.Seedwork;

namespace Quotation.Infra.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190122050310_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Quotation")
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quotation.Domain.Aggregates.CurrencyAgg.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<Guid>("Key");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Quotation.Domain.Aggregates.QuotationAgg.CorrelationPair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseCurrencyId");

                    b.Property<decimal>("Coefficient");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeleatedAt");

                    b.Property<Guid>("Key");

                    b.Property<int>("QuoteCurrencyId");

                    b.HasKey("Id");

                    b.ToTable("CorrelationPair");
                });
#pragma warning restore 612, 618
        }
    }
}
