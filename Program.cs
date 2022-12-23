using Price_Calculator_Kata.Models;
using Price_Calculator_Kata.Services;
using Price_Calculator_Kata.Enums;

namespace Price_Calculator_Kata
{
    public class Program
    {
        public static void Main()
        {

            Product product = new()
            {
                Name = "The Little Prince",
                UPC = 12345,
                Price = 20.25
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

            List<AdditionalCostItem> additionalCosts = new List<AdditionalCostItem>();
            AdditionalCostItem AC = new()
            {
                Name = "Shipping",
                Cost = 12,
                Type = CostType.AbsoluteValue
            };
            additionalCosts.Add(AC);

            StoreRules storeRules = new()
            {
                TaxPercentage = .2,
                specialDiscount = specialDiscount,
                universalDiscount = universalDiscount,
                AdditionalCosts = additionalCosts
            };

            IValidation validation = new Validation();

            validation.CheckProductValidation(product);
            validation.CheckStoreRolesValidation(storeRules);

            IDiscountCalculator discountCalculator = new DiscountsCalculator(storeRules);

            ITaxCalculator taxCalculator = new TaxCalculator(storeRules);

            IAdditionalCostsCalculator additionalCostsCalculator = new AdditionalCostsCalculator(storeRules);

            IPriceCalculator priceCalculator = new PriceCalculator(discountCalculator, taxCalculator, additionalCostsCalculator);

            IReportGenerator reportGenerator = new ReportGenerator(priceCalculator);

            Console.WriteLine(reportGenerator.reportPrice(product));


        }

    }
}
