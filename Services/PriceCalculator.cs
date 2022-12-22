using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        public IDiscountCalculator discountCalculator { get; set; }
        public ITaxCalculator taxCalculator { get; set; }

        public IAdditionalCostsCalculator additionalCostsCalculator { get; set; }

        public PriceCalculator(IDiscountCalculator discountCalculator, ITaxCalculator taxCalculator, IAdditionalCostsCalculator additionalCostsCalculator)
        {
            this.discountCalculator = discountCalculator;
            this.taxCalculator = taxCalculator;
            this.additionalCostsCalculator = additionalCostsCalculator;
        }

        public PriceBreakdown CalculatePrice(Product product)
        {

            DiscountsBreakdown discountsBreakdown = discountCalculator.CalculateDiscounts(product);

            double price = product.Price;
            if(discountsBreakdown.PreTaxDiscount!=null)
                price = Math.Round(price - (double)discountsBreakdown.PreTaxDiscount, 2);
            double TaxAmount = taxCalculator.CalculateTax(price);

            AdditionalCostsBreakdown additionalCostsBreakdown = additionalCostsCalculator.CalculateAdditionalCosts(product);
            double totalAdditionalCosts = 0;
            if(additionalCostsBreakdown.totalCost!=null)
            {
                totalAdditionalCosts = (double)additionalCostsBreakdown.totalCost;
            }

            double totalPrice = Math.Round(product.Price + TaxAmount - discountsBreakdown.TotalDiscount + totalAdditionalCosts, 2);
            PriceBreakdown priceBreakdown = new()
            {
                ProductPrice = product.Price,
                Tax = TaxAmount,
                PreTaxDiscount = discountsBreakdown.PreTaxDiscount,
                PostTaxDiscount = discountsBreakdown.PostTaxDiscount,
                AdditionalCostsResults = additionalCostsBreakdown.additionalCostResults,
                FinalPrice = totalPrice
            };

            return priceBreakdown;
        }
    }
}
