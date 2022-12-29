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
                price = Rounding.ForCalculation(price - (double)discountsBreakdown.PreTaxDiscount);
            double TaxAmount = taxCalculator.CalculateTax(price);

            AdditionalCostsBreakdown additionalCostsBreakdown = additionalCostsCalculator.CalculateAdditionalCosts(product);
            double totalAdditionalCosts = (double)additionalCostsBreakdown.totalCost;

            double totalPrice = Rounding.ForCalculation(product.Price + TaxAmount - discountsBreakdown.TotalDiscount + totalAdditionalCosts);
            PriceBreakdown priceBreakdown = new()
            {
                ProductPrice = product.Price,
                Tax = TaxAmount,
                PreTaxDiscount = discountsBreakdown.PreTaxDiscount,
                TotalDiscount = discountsBreakdown.TotalDiscount,
                AdditionalCostsResults = additionalCostsBreakdown.additionalCostResults,
                FinalPrice = totalPrice
            };

            return priceBreakdown;
        }
    }
}
