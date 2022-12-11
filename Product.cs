namespace Price_Calculator_Kata
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative value.");
                }

                _price = Math.Round(value, 2);
            }
        }

        private static double _taxPercentage = 0.2;
        public static double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tax percentage cannot be a negative value.");
                }

                _taxPercentage = value;
            }
        }

        public Product() { }

        public Product(string? name, int UPC, double price)
        {
            Name = name;
            this.UPC = UPC;
            Price = price;
        }

        public double CalculatePriceWithTax()
        {
            double taxAmount = Math.Round(TaxPercentage * Price, 2);
            double PriceWithTax = Math.Round(Price + taxAmount,2);
            return PriceWithTax;
        }

        public string PriceReport()
        {
            double priceWithTax = CalculatePriceWithTax();
            return $"${Price} before tax and ${priceWithTax} after ${_taxPercentage * 100} % tax.";
        }

    }
}
