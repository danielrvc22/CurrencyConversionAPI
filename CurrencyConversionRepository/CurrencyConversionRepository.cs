using CurrencyRepository.Data;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CurrencyRepository
{
    public class CurrencyConversionRepository : ICurrencyConversionRepository
    {
        private readonly CurrencyDBContext _dbContext;

        public CurrencyConversionRepository(CurrencyDBContext dbContext) {

            _dbContext = dbContext;
        }

    }
}
