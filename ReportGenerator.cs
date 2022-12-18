namespace Price_Calculator_Kata
{
    public class ReportGenerator
    {
        public static string reportPrice(PriceCalculator calc, Product product)
        {
            List<string> reportList = new();

            reportList.Add($"Tax amount = ${calc.CalculateTax(product)},");

            double discountAmount = calc.CalculateTotalDiscount(product);

            if (discountAmount != 0)
            {
                if (calc.getSpecialDiscount().Percentage == 0)
                {
                    reportList.Add($" Universal");
                }
                else if (calc.getUniversalDiscount().Percentage == 0)
                {
                    reportList.Add($" Special");
                }
                else
                {
                    reportList.Add($" Total ");
                }
                reportList.Add($" Discount amount = ${discountAmount},");
            }

            reportList.Add($" Price before = ${product.Price},");

            reportList.Add($" price after = ${calc.CalculateTotalPrice(product)}");

            return String.Join(String.Empty, reportList.ToArray());
        }
    }
}
