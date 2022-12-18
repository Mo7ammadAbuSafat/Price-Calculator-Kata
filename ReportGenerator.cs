namespace Price_Calculator_Kata
{
    public class ReportGenerator
    {
        public static string reportPrice(PriceBreakdown priceBreakdown)
        {
            List<string> reportList = new();

            reportList.Add($"Tax amount = ${priceBreakdown.Tax},");

            reportList.Add($" Total Discount amount = ${priceBreakdown.Discount},");

            reportList.Add($" Price before = ${priceBreakdown.ProductPrice},");

            reportList.Add($" price after = ${priceBreakdown.FinalPrice}");

            return String.Join(String.Empty, reportList.ToArray());
        }
    }
}
