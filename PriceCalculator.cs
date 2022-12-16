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
                CheckPercentageValidation(value, "Tax");
                _taxPercentage = Math.Round(value, 2);
            }
        }

        private double _universalDiscountPercentage = 0;
        public double UniversalDiscountPercentage
        {
            get => _universalDiscountPercentage;
            set
            {
                CheckPercentageValidation(value, "Universal discount");
                _universalDiscountPercentage = Math.Round(value, 2);
            }
        }

        private Tuple<int, double> _specialDiscount = new(-1,0);

        public Tuple<int, double> getSpecialDiscount()
        {
            return _specialDiscount;
        }

        public void setSpecialDiscountPercentage(Tuple<int, double> specialDiscount)
        {
            CheckPercentageValidation(specialDiscount.Item2, "Special discount");
            _specialDiscount = new(specialDiscount.Item1, Math.Round(specialDiscount.Item2, 2));
        }

        public PriceCalculator() { }

        public PriceCalculator(double taxPercentage=0.2, double universalDiscountPercentage=0)
        {
            TaxPercentage = taxPercentage;
            UniversalDiscountPercentage = universalDiscountPercentage;

        }

        public PriceCalculator(double taxPercentage,
                               double universalDiscountPercentage,
                               Tuple<int, double> specialDiscount)
        {
            TaxPercentage = taxPercentage;
            UniversalDiscountPercentage = universalDiscountPercentage;
            setSpecialDiscountPercentage(specialDiscount);
        }

        public static void CheckPercentageValidation(double percentage, string percentageName)
        {
            if (percentage < 0 || percentage > 1)
            {
                throw new ArgumentException($"{percentageName} percentage must be between 0 and 1.");
            }
        }

        public double CalculateTax(Product product)
        {
            return Math.Round(TaxPercentage * product.Price, 2);
        }

        public double CalculateDiscount(Product product)
        {
            double totalDiscount = 0;
            if(product.UPC == getSpecialDiscount().Item1)
            {
                double specialDiscountAmount = Math.Round(getSpecialDiscount().Item2 * product.Price, 2);
                totalDiscount = Math.Round(totalDiscount + specialDiscountAmount, 2);
            }

            if (UniversalDiscountPercentage != 0)
            {
                double universalDiscountAmount = Math.Round(UniversalDiscountPercentage * product.Price, 2);
                totalDiscount = Math.Round(totalDiscount + universalDiscountAmount, 2);
            }

            return totalDiscount;
        }

        public double CalculateTotalPrice(Product product)
        {
            return Math.Round(product.Price + CalculateTax(product) - CalculateDiscount(product), 2);
        }

        public string PriceReport(Product product)
        {
            double taxAmount = CalculateTax(product);

            double discountAmount = CalculateDiscount(product);

            double priceAfter = CalculateTotalPrice(product);

            string discountAmountInReport;

            if (UniversalDiscountPercentage == 0 && getSpecialDiscount().Item2 == 0)
            {
                discountAmountInReport = "";
            }
            else if(getSpecialDiscount().Item2 == 0)
            {
                discountAmountInReport = $" Universal Discount amount = ${discountAmount},";
            }
            else if (UniversalDiscountPercentage == 0)
            {
                discountAmountInReport = $" Special Discount amount = ${discountAmount},";
            }
            else
            {
                discountAmountInReport = $" Total Discount amount = ${discountAmount},";
            }

            return $"Tax amount = ${taxAmount}," +
                   discountAmountInReport +
                   $" Price before = ${product.Price}," +
                   $" price after = ${priceAfter}";
        }
                
    }
}
