using System.Diagnostics;

namespace Price_Calculator_Kata
{
    public class StoreRules
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

        public StoreRules()
        {
        }
        public StoreRules(double taxPercentage) 
        {
            TaxPercentage = taxPercentage;
        }

        public StoreRules(double taxPercentage, UniversalDiscount universalDiscount)
        {
            TaxPercentage = taxPercentage;
            setUniversalDiscount(universalDiscount);
        }

        public StoreRules(double taxPercentage, UniversalDiscount universalDiscount, SpecialDiscount specialDiscount)
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

    }
}
