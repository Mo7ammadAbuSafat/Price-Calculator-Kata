namespace Price_Calculator_Kata
{
    public class ReportGenerator
    {
        public static string reportPrice(PriceBreakdown priceBreakdown)
        {
            
            List<string> reportList = new();
            
            reportList.Add($"Tax amount = ${priceBreakdown.Tax},");

            if (priceBreakdown.PreTaxDiscount != null)
            {
                reportList.Add($" Pre Tax Discount amount = ${priceBreakdown.PreTaxDiscount},");
            }

            if (priceBreakdown.PostTaxDiscount != null)
            {
                reportList.Add($" Post Tax Discount amount = ${priceBreakdown.PostTaxDiscount},");
            }

            reportList.Add($" Price before = ${priceBreakdown.ProductPrice},");

            reportList.Add($" price after = ${priceBreakdown.FinalPrice}");

            return String.Join(String.Empty, reportList.ToArray());
        }
    }
}
