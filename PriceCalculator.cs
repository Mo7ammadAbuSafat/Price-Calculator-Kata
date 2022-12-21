namespace Price_Calculator_Kata
{
    public class PriceCalculator
    {
        public Product product { get; set; }

        public StoreRules storeRules { get; set; }

        public DiscountsCalculator discountsCalculator { get; set; }

        public PriceCalculator(Product product, StoreRules storeRules)
        {
            this.product = product;
            this.storeRules = storeRules;
            discountsCalculator = new(storeRules, product);
        }

        public double CalculateTax()
        {
            double priceForTax = product.Price;

            if (discountsCalculator.CalculatePreTaxDiscount() != null)
            {
                priceForTax = Math.Round(priceForTax - (double)discountsCalculator.CalculatePreTaxDiscount(), 2);
            }

            return Math.Round(storeRules.TaxPercentage * priceForTax, 2);
        }

        public double CalculateTotalPrice()
        {
            return Math.Round(product.Price + CalculateTax() - discountsCalculator.CalculateTotalDiscount(), 2);
        }

        public PriceBreakdown CalculatePrice()
        {
            PriceBreakdown priceBreakdown = new()
            {
                ProductPrice = product.Price,
                Tax = CalculateTax(),
                PreTaxDiscount = discountsCalculator.CalculatePreTaxDiscount(),
                PostTaxDiscount = discountsCalculator.CalculatePostTaxDiscount(),
                FinalPrice = CalculateTotalPrice()
            };

            return priceBreakdown;
        }
        
    }
}
