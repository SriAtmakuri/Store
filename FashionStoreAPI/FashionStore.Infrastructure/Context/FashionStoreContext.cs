using FashionStore.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Infrastructure.Context
{
    public class FashionStoreContext : DbContext
    {
        public FashionStoreContext(DbContextOptions<FashionStoreContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed CurrencyExchanges
            modelBuilder.Entity<CurrencyExchangeRate>().HasData(
                new CurrencyExchangeRate { CurrencyExchangeRateId=1, ExchangeRate = 1.24M, CurrencyCode = "USD", ValidFromDate = new DateTime(2023, 11, 1) },
                new CurrencyExchangeRate { CurrencyExchangeRateId = 2, ExchangeRate = 1.14M, CurrencyCode = "EUR", ValidFromDate = new DateTime(2023, 11, 1) },
                new CurrencyExchangeRate { CurrencyExchangeRateId = 3, ExchangeRate = 1.92M, CurrencyCode = "AUD", ValidFromDate = new DateTime(2023, 11, 1) },
                new CurrencyExchangeRate { CurrencyExchangeRateId = 4,ExchangeRate = 1.29M, CurrencyCode = "USD", ValidFromDate = new DateTime(2023, 10, 1), ValidToDate = new DateTime(2023, 10, 31) },
                new CurrencyExchangeRate { CurrencyExchangeRateId = 5, ExchangeRate = 1.16M, CurrencyCode = "EUR", ValidFromDate = new DateTime(2023, 10, 1), ValidToDate = new DateTime(2023, 10, 31) }
            );

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "United States of America", CountryCode = "USA", CurrencyCode = "USD" },
                new Country { CountryId = 2, Name = "Deutschland", CountryCode = "DEU", CurrencyCode = "EUR" },
                new Country { CountryId = 3, Name = "Australia", CountryCode = "AUS", CurrencyCode = "AUD" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId=1, Name = "T-shirt", Description = "Mens t-shirt, size medium", Price = 19.99M },
                new Product { ProductId=2, Name = "Jeans", Description = "Womens jeans, size small", Price = 45.99M },
                new Product { ProductId=3, Name = "Hat", Description = "Summer hat, one size", Price = 10.99M },
                new Product { ProductId=4, Name = "Coat", Description = "Unisex winter jacket, size large", Price = 80.99M },
                new Product { ProductId=5, Name = "Trainers", Description = "Womens fashion footwear, size 37", Price = 55.99M }
            );
        }
    }
}
