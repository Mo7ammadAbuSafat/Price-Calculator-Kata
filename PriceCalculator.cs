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
            CheckPercentageValidation(universalDiscount.Percentage, "Universal discount");
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
            double priceForTax = product.Price;

            if (CalculatePostTaxDiscount(product) != null)
            {
                priceForTax = Math.Round(priceForTax - (double)CalculatePostTaxDiscount(product), 2);
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

        public double? CalculatePreTaxDiscount(Product product)
        {
            double PreTaxDiscount = 0;
            if (_universalDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateUniversalDiscount(product), 2);
            }
            if (_specialDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateSpecialDiscount(product), 2);
            }

            return PreTaxDiscount==0 ? null : PreTaxDiscount;
        }

        public double? CalculatePostTaxDiscount(Product product)
        {
            double PostTaxDiscount = 0;
            if (_universalDiscount?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateUniversalDiscount(product), 2);
            }
            if (_specialDiscount?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateSpecialDiscount(product), 2);
            }

            return PostTaxDiscount == 0 ? null : PostTaxDiscount;
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
                PreTaxDiscount = CalculatePreTaxDiscount(product),
                PostTaxDiscount = CalculatePostTaxDiscount(product),
                FinalPrice = CalculateTotalPrice(product)
            };

            return priceBreakdown;
        }

    }
}
