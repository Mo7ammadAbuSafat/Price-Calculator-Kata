namespace Price_Calculator_Kata.Models
{
    public class PriceBreakdown
    {
        public double ProductPrice { get; set; }
        public double? PreTaxDiscount { get; set; }
        public double Tax { get; set; }
        public double? PostTaxDiscount { get; set; }
        public List<AdditionalCostItemResult>? AdditionalCostsResults { get; set; }
        public double FinalPrice { get; set; }

    }
}
