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

        public double CalculateTax(double price)
        {
            return Math.Round(TaxPercentage * price, 2);
        }

        public double CalculateDiscount(double price)
        {
            return Math.Round(DiscountPercentage * price, 2);

        }
    }
}
