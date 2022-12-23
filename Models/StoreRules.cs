using Price_Calculator_Kata.Services;

namespace Price_Calculator_Kata.Models
{
    public class StoreRules
    {
        public double TaxPercentage { get; set; }

        public UniversalDiscount? universalDiscount{ get; set; }

        public SpecialDiscount? specialDiscount{ get; set; }

        public List<AdditionalCostItem> AdditionalCosts { get; set; }
    }
}
