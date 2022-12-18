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

        private UniversalDiscount _universalDiscount = new(0,true);

        public UniversalDiscount getUniversalDiscount()
        {
            return _universalDiscount;
        }

        public void setUniversalDiscount(UniversalDiscount universalDiscount)
        {
            CheckPercentageValidation(universalDiscount.Percentage, "Special discount");
            _universalDiscount.Percentage = universalDiscount.Percentage;
            _universalDiscount.IsTaxCalculatedAfter = universalDiscount.IsTaxCalculatedAfter;
        }


        private SpecialDiscount _specialDiscount = new(-1, 0, true);

        public SpecialDiscount getSpecialDiscount()
        {
            return _specialDiscount;
        }

        public void setSpecialDiscount(SpecialDiscount specialDiscount)
        {
            CheckPercentageValidation(specialDiscount.Percentage, "Special discount");
            _specialDiscount.UPC = specialDiscount.UPC;
            _specialDiscount.Percentage = specialDiscount.Percentage;
            _specialDiscount.IsTaxCalculatedAfter = specialDiscount.IsTaxCalculatedAfter;
        }

        public PriceCalculator(double taxPercentage = 0.2) 
        {
            TaxPercentage = taxPercentage;
        }

        public PriceCalculator(double taxPercentage, UniversalDiscount universalDiscount)
        {
            TaxPercentage = taxPercentage;
            setUniversalDiscount(universalDiscount);
        }

        public PriceCalculator(double taxPercentage, UniversalDiscount universalDiscount, SpecialDiscount specialDiscount)
        {
            TaxPercentage = taxPercentage;
            setUniversalDiscount(universalDiscount);
            setSpecialDiscount(specialDiscount);
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
            double priceForTax= product.Price;
            if (_universalDiscount.IsTaxCalculatedAfter)
            {
                priceForTax = Math.Round(priceForTax - CalculateUniversalDiscount(product), 2);
            }
            if (_specialDiscount.IsTaxCalculatedAfter)
            {
                priceForTax = Math.Round(priceForTax - CalculateSpecialDiscount(product), 2);
            }
            return Math.Round(TaxPercentage * priceForTax, 2);
        }

        public double CalculateSpecialDiscount(Product product)
        {
            if (product.UPC == getSpecialDiscount().UPC)
            {
                return Math.Round(getSpecialDiscount().Percentage * product.Price, 2);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount(Product product)
        {
            return Math.Round(getUniversalDiscount().Percentage * product.Price, 2);
        }

        public double CalculateTotalDiscount(Product product)
        {
            return Math.Round(CalculateSpecialDiscount(product) + CalculateUniversalDiscount(product), 2);
        }

        public double CalculateTotalPrice(Product product)
        {
            return Math.Round(product.Price + CalculateTax(product) - CalculateTotalDiscount(product), 2);
        }

        public string PriceReport(Product product)
        {
            List<string> reportList = new();

            reportList.Add($"Tax amount = ${CalculateTax(product)},");

            double discountAmount = CalculateTotalDiscount(product);

            if (discountAmount != 0) {
                if (_specialDiscount.Percentage == 0)
                {
                    reportList.Add($" Universal");
                }
                else if (_universalDiscount.Percentage == 0)
                {
                    reportList.Add($" Special");
                }
                else
                {
                    reportList.Add($" Total ");
                }
                reportList.Add($" Discount amount = ${discountAmount},");
            }

            reportList.Add($" Price before = ${product.Price},");

            reportList.Add($" price after = ${CalculateTotalPrice(product)}");

            return String.Join(String.Empty, reportList.ToArray());
        }
                
    }
}
