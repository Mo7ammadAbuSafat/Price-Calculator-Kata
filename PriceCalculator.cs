using System.Diagnostics;

namespace Price_Calculator_Kata
{
    public class PriceCalculator
    {
        private double _taxPercentage;
        public double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                CheckPercentageValidation(value, "Tax");
                _taxPercentage = Math.Round(value, 2);
            }
        }

        private UniversalDiscount? _universalDiscount;

        public UniversalDiscount? getUniversalDiscount()
        {
            return _universalDiscount;
        }

        public void setUniversalDiscount(UniversalDiscount universalDiscount)
        {
            CheckPercentageValidation(universalDiscount.Percentage, "Special discount");
            _universalDiscount = universalDiscount;

        }


        private SpecialDiscount? _specialDiscount;

        public SpecialDiscount? getSpecialDiscount()
        {
            return _specialDiscount;
        }

        public void setSpecialDiscount(SpecialDiscount specialDiscount)
        {
            CheckPercentageValidation(specialDiscount.Percentage, "Special discount");
            _specialDiscount = specialDiscount;
        }

        public PriceCalculator()
        {
        }
        public PriceCalculator(double taxPercentage) 
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
            if (_universalDiscount?.DiscountType==Type.PRE_TAX)
            {
                priceForTax = Math.Round(priceForTax - CalculateUniversalDiscount(product), 2);
            }
            if (_specialDiscount?.DiscountType == Type.PRE_TAX)
            {
                priceForTax = Math.Round(priceForTax - CalculateSpecialDiscount(product), 2);
            }
            return Math.Round(TaxPercentage * priceForTax, 2);
        }

        public double CalculateSpecialDiscount(Product product)
        {
            if (getSpecialDiscount() == null) return 0;
            if (product.UPC == getSpecialDiscount().UPC)
            {
                return Math.Round(getSpecialDiscount().Percentage * product.Price, 2);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount(Product product)
        {
            if (getUniversalDiscount() == null)
                return 0;
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

        public PriceBreakdown CalculatePrice(Product product)
        {
            PriceBreakdown priceBreakdown = new()
            {
                ProductPrice = product.Price,
                Tax = CalculateTax(product),
                Discount = CalculateTotalDiscount(product),
                FinalPrice = CalculateTotalPrice(product)
            };

            return priceBreakdown;
        }

    }
}
