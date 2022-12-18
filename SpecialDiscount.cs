namespace Price_Calculator_Kata
{
    public class SpecialDiscount
    {
        public int UPC { get; set; }
        public double Percentage { get; set; }
        public Type DiscountType { get; set; }

        public SpecialDiscount(int UPC, double Percentage, Type DiscountType)
        {
            this.UPC = UPC;
            this.Percentage = Percentage;
            this.DiscountType = DiscountType;
        }
    }
}
