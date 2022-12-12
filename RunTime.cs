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

            Console.WriteLine(product.PriceReport());

            Product.TaxPercentage = 0.25;

            Console.WriteLine(product.PriceReport());
        }
        
    }
}
