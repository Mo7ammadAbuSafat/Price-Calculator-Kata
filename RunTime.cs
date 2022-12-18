namespace Price_Calculator_Kata
{
    public class RunTime
    {
        public static void Main()
        {

            Product product = new()
            {
                Name= "The Little Prince",
                UPC= 12345,
                Price= 20.25
            };

            PriceCalculator calc = new(0.2,new(.15, false), new(12345, 0.07, true));
            Console.WriteLine(ReportGenerator.reportPrice(calc,product));

        }
        
    }
}
