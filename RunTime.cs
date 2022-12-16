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

            PriceCalculator calc = new();
            Console.WriteLine(calc.PriceReport(product));

            calc = new(0.25);
            Console.WriteLine(calc.PriceReport(product));

            calc = new(0.25, 0.15);
            Console.WriteLine(calc.PriceReport(product));

            calc = new(0.25, 0.15, 12345, 0.3);
            Console.WriteLine(calc.PriceReport(product));

        }
        
    }
}
