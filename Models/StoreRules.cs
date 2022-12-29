using Price_Calculator_Kata.Enums;
using Price_Calculator_Kata.Services;

namespace Price_Calculator_Kata.Models
{
    public class StoreRules
    {
        public double TaxPercentage { get; set; }

        public UniversalDiscount? universalDiscount{ get; set; }

        public SpecialDiscount? specialDiscount{ get; set; }

        public Cap cap { get; set; }

        public MethodsOfCombiningDiscounts CombiningDiscountsType { get; set; }

        public String Currecny { get; set; }

        public List<AdditionalCostItem> AdditionalCosts { get; set; }
    }
}