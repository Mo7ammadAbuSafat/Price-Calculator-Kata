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

        private SpecialDiscountPair _specialDiscount = new(-1,0);

        public SpecialDiscountPair getSpecialDiscount()
        {
            return _specialDiscount;
        }

        public void setSpecialDiscount(int UPC, double Percentage)
        {
            CheckPercentageValidation(Percentage, "Special discount");
            _specialDiscount.UPC = UPC;
            _specialDiscount.Percentage = Percentage;
        }

        public PriceCalculator() { }

        public PriceCalculator(double taxPercentage=0.2, double universalDiscountPercentage=0)
        {
            TaxPercentage = taxPercentage;
            UniversalDiscountPercentage = universalDiscountPercentage;
        }

        public PriceCalculator(double taxPercentage,
                               double universalDiscountPercentage,
                               int UPC,
                               double Percentage)
        {
            TaxPercentage = taxPercentage;
            UniversalDiscountPercentage = universalDiscountPercentage;
            setSpecialDiscount(UPC,Percentage);
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
            if(product.UPC == getSpecialDiscount().UPC)
            {
                double specialDiscountAmount = Math.Round(getSpecialDiscount().Percentage * product.Price, 2);
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
            List<string> reportList = new();

            reportList.Add($"Tax amount = ${CalculateTax(product)},");

            double discountAmount = CalculateDiscount(product);

            if (discountAmount != 0) {
                if (getSpecialDiscount().Percentage == 0)
                {
                    reportList.Add($" Universal Discount amount = ${discountAmount},");
                }
                else if (UniversalDiscountPercentage == 0)
                {
                    reportList.Add($" Special Discount amount = ${discountAmount},");
                }
                else
                {
                    reportList.Add($" Total Discount amount = ${discountAmount},");
                }
            }

            reportList.Add($" Price before = ${product.Price},");

            reportList.Add($" price after = ${CalculateTotalPrice(product)}");

            return String.Join(String.Empty, reportList.ToArray());
        }
                
    }
}
