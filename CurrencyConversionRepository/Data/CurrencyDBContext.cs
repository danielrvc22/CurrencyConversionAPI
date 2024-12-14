using CurrencyRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRepository.Data
{
    public class CurrencyDBContext : DbContext
    {

        public CurrencyDBContext(DbContextOptions<CurrencyDBContext> options)  : base(options) {
        }

        DbSet<CurrencyModel> Currencies {  get; set; }   
    }
}
