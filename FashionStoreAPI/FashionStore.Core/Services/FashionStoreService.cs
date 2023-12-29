using FashionStore.Core.Interfaces.Repositories;
using FashionStore.Core.Interfaces.Services;
using FashionStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Services
{
    public class FashionStoreService:IFashionStoreService
    {
        private readonly IFashionStoreRepository _repository;

        public FashionStoreService(IFashionStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetProducts()
        {
          return await _repository.GetProducts();

        }

        public async Task<List<Country>> GetCountries()
        {
            return await _repository.GetCountries();
        }

        public async Task<CurrencyExchangeRate> GetCurrency(string currencyCode)
        {
            return await _repository.GetCurrency(currencyCode);
        }
    }
}
