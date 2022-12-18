namespace Price_Calculator_Kata
{
    public class SpecialDiscount
    {
        public int UPC { get; set; }
        public double Percentage { get; set; }

        public bool IsTaxCalculatedAfter { get; set; }

        public SpecialDiscount(int UPC, double Percentage, bool IsTaxCalculatedAfter)
        {
            this.UPC = UPC;
            this.Percentage = Percentage;
            this.IsTaxCalculatedAfter = IsTaxCalculatedAfter;
        }
    }
}
