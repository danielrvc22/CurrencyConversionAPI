using CurrencyRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRepository
{
    public  interface ICurrencyConversionRepository
    {
        public Task<CurrencyModel> GetCurrencyConversion(decimal amount, string currencyOrigin, string currencyTarget);
        public Task<string> UpdateConversionValue(CurrencyModel currencyModel);

    }
}
