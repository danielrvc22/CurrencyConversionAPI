namespace CurrencyConversionAPI.DTO
{
    public class CurrencyConversionResponse
    {
        public decimal ConversionValue { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyTarget { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountConversion { get; set; }

    }
}
