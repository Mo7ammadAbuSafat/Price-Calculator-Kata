namespace Price_Calculator_Kata.Models
{
    public class StoreRules
    {
        private double _taxPercentage;
        public double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                Validation.CheckPercentageValidation(value, "Tax");
                _taxPercentage = Math.Round(value, 2);
            }
        }

        private UniversalDiscount? _universalDiscount;

        public UniversalDiscount? universalDiscount
        {
            get => _universalDiscount;
            set
            {
                Validation.CheckPercentageValidation(value.Percentage, "Universal discount");
                _universalDiscount = value;
            }
        }
        

        private SpecialDiscount? _specialDiscount;

        public SpecialDiscount? specialDiscount
        {
            get => _specialDiscount;
            set
            {
                Validation.CheckPercentageValidation(value.Percentage, "Special discount");
                _specialDiscount = value;
            }
        }


    }
}
