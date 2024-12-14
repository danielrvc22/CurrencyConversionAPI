using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRepository.Models
{
    public class CurrencyModel
    {
        [Precision(18, 2)]
        public decimal ConversionValue { get; set; }

        [Key]
        public string DateConversion {  get; set; }
    }
}
