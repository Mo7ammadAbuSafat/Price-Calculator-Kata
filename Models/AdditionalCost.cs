using Price_Calculator_Kata.Enums;

namespace Price_Calculator_Kata.Models
{
    public class AdditionalCostItem
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public CostType Type { get; set; }

    }
}
