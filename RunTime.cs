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

            PriceCalculator calc = new(0.2, 0.15);

            Console.WriteLine(calc.PriceReport(product));

            PriceCalculator calc2 = new();
            Console.WriteLine(calc2.PriceReport(product));

        }
        
    }
}
