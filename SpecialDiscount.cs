namespace Price_Calculator_Kata
{
    public class SpecialDiscount
    {
        public int UPC { get; set; }
        public double Percentage { get; set; }
        public DiscountType Type { get; set; }

        public SpecialDiscount(int UPC, double Percentage, DiscountType Type)
        {
            this.UPC = UPC;
            this.Percentage = Percentage;
            this.Type = Type;
        }
    }
}
