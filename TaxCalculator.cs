namespace Price_Calculator_Kata
{
    public class TaxCalculator
    {

        DiscountsCalculator discountsCalculator;
        public Product product;

        public TaxCalculator(DiscountsCalculator discountsCalculator, Product product)
        {
            this.discountsCalculator = discountsCalculator;
            this.product = product;
        }
        public double CalculateTax()
        {
            double priceForTax = product.Price;

            if (discountsCalculator.CalculatePreTaxDiscount() != null)
            {
                priceForTax = Math.Round(priceForTax - (double)discountsCalculator.CalculatePreTaxDiscount(), 2);
            }


            return Math.Round(TaxPercentage * priceForTax, 2);
        }
    }
}
