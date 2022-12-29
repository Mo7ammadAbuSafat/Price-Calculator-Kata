namespace Price_Calculator_Kata.Services
{
    public static class Rounding
    {
        public static double ForCalculation(double amount)
        {
            return Math.Round(amount,4);
        }

        public static double ForReport(double amount)
        {
            return Math.Round(amount, 2);
        }
    }
}
