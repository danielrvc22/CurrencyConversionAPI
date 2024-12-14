

using CurrencyRepository;

namespace CurrencyConversionAPI.InjectionDependency
{
    public static class InjectionDependency
    {

        public static void Inject(WebApplicationBuilder? builder)
        {
            

            // repository
            builder?.Services.AddScoped<ICurrencyConversionRepository, CurrencyConversionRepository>();

          
        }
    }
}
