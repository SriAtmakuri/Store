using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Infrastructure.Entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
