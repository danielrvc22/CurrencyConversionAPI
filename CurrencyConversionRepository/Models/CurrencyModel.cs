using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRepository.Models
{
    [PrimaryKey(nameof(DateConversion), nameof(CurrencyOrigin), nameof(CurrencyTarget))]
    public class CurrencyModel
    {
        [Precision(18, 2)]
        public decimal ConversionValue { get; set; }

       
        public string DateConversion {  get; set; }
     
        public string CurrencyOrigin { get; set; }
        public string CurrencyTarget { get; set; }
    }
}
