using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata
{
    public class PriceCalculator
    {
        public StoreRules storeRules { get; set; }

        public PriceBreakdown CalculatePrice(Product product)
        {
            DiscountsCalculator discountsCalculator = new()
            {
                storeRules = storeRules,
            };

            DiscountsBreakdown discountsBreakdown = discountsCalculator.CalculateDiscounts(product);

            TaxCalculator taxCalculator = new()
            {
                storeRules = storeRules,
            };

            double TaxAmount = taxCalculator.CalculateTax(product, discountsBreakdown.PreTaxDiscount);

            PriceBreakdown priceBreakdown = new()
            {
                ProductPrice = product.Price,
                Tax = TaxAmount,
                PreTaxDiscount = discountsBreakdown.PreTaxDiscount,
                PostTaxDiscount = discountsBreakdown.PostTaxDiscount,
                FinalPrice = Math.Round(product.Price + TaxAmount - discountsBreakdown.TotalDiscount, 2),
            };

            return priceBreakdown;
        }
        
    }
}
