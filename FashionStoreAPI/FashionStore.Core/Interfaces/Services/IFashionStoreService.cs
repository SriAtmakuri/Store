using FashionStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Interfaces.Services
{
    public interface IFashionStoreService
    {
        Task<List<Product>> GetProducts();
        Task<List<Country>> GetCountries();
        Task<CurrencyExchangeRate> GetCurrency(string currencyCode);
    }
}
