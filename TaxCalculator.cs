using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata
{
    public class TaxCalculator
    {
        public StoreRules storeRules { get; set; }
        public double CalculateTax(Product product, double? preTaxDiscount)
        {
            double priceForTax = product.Price;
            if(preTaxDiscount != null)
            {
                priceForTax = Math.Round(priceForTax - (double)preTaxDiscount, 2);
            }

            return Math.Round(storeRules.TaxPercentage * priceForTax, 2);
        }
    }
}
