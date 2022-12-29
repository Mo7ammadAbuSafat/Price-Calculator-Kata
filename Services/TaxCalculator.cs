using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        public StoreRules storeRules { get; set; }

        public TaxCalculator(StoreRules storeRules)
        {
            this.storeRules = storeRules;
        }
    
        public double CalculateTax(double productPrice)
        {
            return Rounding.ForCalculation(storeRules.TaxPercentage * productPrice);
        }
    }
}
