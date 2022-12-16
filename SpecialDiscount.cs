namespace Price_Calculator_Kata
{
    public class SpecialDiscountPair
    {
        public int UPC { get; set; }
        public double Percentage { get; set; }

        public SpecialDiscountPair(int uPC, double Percentage)
        {
            UPC = uPC;
            this.Percentage = Percentage;
        }
    }
}
