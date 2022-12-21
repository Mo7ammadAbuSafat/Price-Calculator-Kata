namespace Price_Calculator_Kata
{
    public class Validation
    {
        public static void CheckPercentageValidation(double percentage, string percentageName)
        {
            if (percentage < 0 || percentage > 1)
            {
                throw new ArgumentException($"{percentageName} percentage must be between 0 and 1.");
            }
        }
    }
}
