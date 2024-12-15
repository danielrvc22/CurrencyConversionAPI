using CurrencyRepository.Data;
using CurrencyRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRepository
{
    public class CurrencyConversionRepository : ICurrencyConversionRepository
    {
        private readonly CurrencyDBContext _dbContext;

        public CurrencyConversionRepository(CurrencyDBContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<CurrencyModel> GetCurrencyConversion(decimal amount, string currencyOrigin, string currencyTarget)
        {
            var list = await _dbContext.Currencies.ToListAsync();

            var findItem = list.FirstOrDefault(x => x.CurrencyOrigin == currencyOrigin && x.CurrencyTarget == currencyTarget && x.DateConversion == DateTime.Now.ToString("dd/MM/yyyy"));

            return findItem;
        }

        public async Task<string> UpdateConversionValue(CurrencyModel currency)
        {
            string msjResult = string.Empty;
            if (_dbContext.Currencies.ToList().Exists(x => x.CurrencyOrigin == currency.CurrencyOrigin && x.CurrencyTarget == currency.CurrencyTarget && x.DateConversion == currency.DateConversion))
            {
                _dbContext.Currencies.Update(currency);
                _dbContext.Currencies.Update(currency).State = EntityState.Modified;

                int rowAffect = await _dbContext.SaveChangesAsync();
                if (rowAffect > 0)
                {
                    msjResult = "Se actualizo correctamente el tipo de cambio.";
                }
            }

            else
            {
                _dbContext.Currencies.Add(currency);
                _dbContext.Currencies.Add(currency).State = EntityState.Added;
                int rowAffect = await _dbContext.SaveChangesAsync();
                msjResult = "Se agregó información para actualizar.";
            }

            return msjResult;
        }
    }
}
