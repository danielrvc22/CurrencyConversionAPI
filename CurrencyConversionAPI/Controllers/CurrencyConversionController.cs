using CurrencyConversionAPI.DTO;
using CurrencyRepository;
using CurrencyRepository.Data;
using CurrencyRepository.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConversionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyConversionController : ControllerBase
    {

       
        private readonly ICurrencyConversionRepository _currencyConversionRepository;

        public CurrencyConversionController (ICurrencyConversionRepository currencyDBContext)
        {
           _currencyConversionRepository = currencyDBContext;
        }

      

        
        [HttpGet("Conversion")]
        public async Task<IActionResult> CurrencyConversion(decimal amount  ,  string currencyOrigin , string currencyTarget)
        {
            Console.WriteLine("Conversion" + DateTime.Now);
            var currencyData = await _currencyConversionRepository.GetCurrencyConversion(amount, currencyOrigin, currencyTarget);

            if (currencyData != null)
            {

                var result = new CurrencyConversionResponse()
                {
                    Amount = amount,
                    CurrencyOrigin = currencyOrigin,
                    CurrencyTarget = currencyTarget,
                    AmountConversion = amount * currencyData.ConversionValue,
                    ConversionValue = currencyData.ConversionValue

                };

                return Ok(result);
            }
            else { 
             return NotFound("No se encontro  tipo de cambio para la moneda de Origen y Destino.");
            }

           
        }

        

        // POST api/<CurrencyConversionController>
        [HttpPost("UpdateConversionValue")]
        public async Task<string> UpdateConversionValue(string currencyOrigin, string currencyTarget , decimal conversionValue)
        {
            Console.WriteLine("UpdateConversionValue" + DateTime.Now);
            CurrencyModel currency = new CurrencyModel {
                ConversionValue = conversionValue,
                CurrencyOrigin = currencyOrigin,
                CurrencyTarget = currencyTarget,
                DateConversion = DateTime.Now.ToString("dd/MM/yyyy")
            };
            var result = await _currencyConversionRepository.UpdateConversionValue(currency);

            return result;

        }

     
    }
}
