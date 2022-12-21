using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata
{
    public class RunTime
    {
        public static void Main()
        {

            Product product = new()
            {
                Name= "The Little Prince",
                UPC= 12345,
                Price= 20.25
            };

            UniversalDiscount universalDiscount = new()
            {
                Percentage = .15,
                Type = DiscountType.POST_TAX
            };

            SpecialDiscount specialDiscount = new()
            {
                Percentage = 0.07,
                UPC = 12345,
                Type = DiscountType.PRE_TAX
            };

            StoreRules storeRules = new()
            {
                TaxPercentage = .2,
                specialDiscount = specialDiscount,
                universalDiscount = universalDiscount
            };

            PriceCalculator priceCalculator = new()
            {
                storeRules = storeRules,
            };

            PriceBreakdown priceBreakdown = priceCalculator.CalculatePrice(product);
            Console.WriteLine(ReportGenerator.reportPrice(priceBreakdown));


        }
        
    }
}
