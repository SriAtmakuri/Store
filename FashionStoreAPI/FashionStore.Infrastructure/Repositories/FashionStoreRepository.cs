using FashionStore.Core.Interfaces.Repositories;
using FashionStore.Core.Models;
using FashionStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Infrastructure.Repositories
{
    public class FashionStoreRepository:IFashionStoreRepository
    {
        private readonly FashionStoreContext _dbContext;
        public FashionStoreRepository(FashionStoreContext dbcontext)
        {
            _dbContext = dbcontext;   
        }

        public async Task<List<Product>> GetProducts()
        {
            var data = await (from product in _dbContext.Products
                              select new Product
                              {
                                  ProductId = product.ProductId,
                                  Description = product.Description,
                                  Name = product.Name,
                                  Price = product.Price
                              }).ToListAsync();
            return data;
        }
        public async Task<List<Country>> GetCountries()
        {
            var data = await (from country in _dbContext.Countries
                              select new Country
                              {
                                  Name= country.Name,
                                  CountryCode = country.CountryCode,        
                                  CountryId = country.CountryId,
                                  CurrencyCode =country.CurrencyCode
                                  
                              }).ToListAsync();
            return data;
        }

        public async Task<CurrencyExchangeRate> GetCurrency(string currencyCode)
        {
            var data = await (from currency in _dbContext.CurrencyExchangeRates
                              where currency.CurrencyCode==currencyCode && (currency.ValidToDate>=DateTime.Now || currency.ValidToDate== null)
                              select new CurrencyExchangeRate
                              {
                                 CurrencyCode =currency.CurrencyCode,
                                 CurrencyExchangeRateId = currency.CurrencyExchangeRateId,  
                                 ExchangeRate=currency.ExchangeRate,
                                 ValidFromDate= currency.ValidFromDate,
                                 ValidToDate = currency.ValidToDate

                              }).FirstOrDefaultAsync();

            return data ?? new CurrencyExchangeRate();
        }
    }
}
