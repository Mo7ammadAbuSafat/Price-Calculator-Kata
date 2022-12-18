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
            PriceBreakdown priceBreakdown = calc.CalculatePrice(product);
            Console.WriteLine(ReportGenerator.reportPrice(priceBreakdown));

            calc = new(0.2);
            priceBreakdown = calc.CalculatePrice(product);
            Console.WriteLine(ReportGenerator.reportPrice(priceBreakdown));

            calc = new(0.2, new(.15, Type.POST_TAX));
            priceBreakdown = calc.CalculatePrice(product);
            Console.WriteLine(ReportGenerator.reportPrice(priceBreakdown));

            calc = new(0.2, new(.15, Type.POST_TAX), new(12345, 0.07, Type.PRE_TAX));
            priceBreakdown = calc.CalculatePrice(product);
            Console.WriteLine(ReportGenerator.reportPrice(priceBreakdown));

        }
        
    }
}
