namespace Price_Calculator_Kata
{
    public class UniversalDiscount
    {
        public double Percentage { get; set; }

        public Type DiscountType { get; set; }

        public UniversalDiscount(double Percentage, Type DiscountType)
        {
            this.Percentage = Percentage;
            this.DiscountType = DiscountType;
        }
    }
}
