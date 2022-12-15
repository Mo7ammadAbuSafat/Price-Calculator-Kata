using System.Diagnostics;

namespace Price_Calculator_Kata
{
    public class PriceCalculator
    {
        private double _taxPercentage = 0.2;
        public double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tax percentage cannot be a negative value.");
                }

                _taxPercentage = value;
            }
        }

        private double _discountPercentage = 0;
        public double DiscountPercentage
        {
            get => _discountPercentage;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Discount percentage must be between 0 and 1.");
                }

                _discountPercentage = value;
            }
        }

        public PriceCalculator() { }

        public PriceCalculator(double taxPercentage, double discountPercentage)
        {
            TaxPercentage = taxPercentage;
            DiscountPercentage = discountPercentage;
        }

        public double CalculateTax(Product product)
        {
            return Math.Round(TaxPercentage * product.Price, 2);
        }

        public double CalculateDiscount(Product product)
        {
            return Math.Round(DiscountPercentage * product.Price, 2);
        }

        public double CalculateTotalPrice(Product product)
        {
            return Math.Round(product.Price + CalculateTax(product) - CalculateDiscount(product), 2); ;
        }

        public string PriceReport(Product product)
        {
            double taxAmount = CalculateTax(product);
            double discountAmount = CalculateDiscount(product); ;

            double priceAfter = CalculateTotalPrice(product);

            string discountPercentageInReport = "";
            string discountAmountInReport = "";
            if (DiscountPercentage != 0)
            {
                discountAmountInReport = $" Discount amount = ${discountAmount},";
                discountPercentageInReport = $"discount={DiscountPercentage * 100}%,";
            }

            return $"Tax={TaxPercentage * 100}%," +
                   discountPercentageInReport +
                   $"Tax amount = ${taxAmount}," +
                   discountAmountInReport +
                   $" Price before = ${product.Price}," +
                   $" price after = ${priceAfter}";
        }




    }
}
