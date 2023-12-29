using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Models
{
    public class CurrencyExchangeRate
    {
        public int CurrencyExchangeRateId { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ValidToDate { get; set; }
    }
}
