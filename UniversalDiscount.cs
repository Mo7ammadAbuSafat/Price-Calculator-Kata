namespace Price_Calculator_Kata
{
    public class UniversalDiscount
    {
        public double Percentage { get; set; }

        public DiscountType Type { get; set; }

        public UniversalDiscount(double Percentage, DiscountType Type)
        {
            this.Percentage = Percentage;
            this.Type = Type;
        }
    }
}
