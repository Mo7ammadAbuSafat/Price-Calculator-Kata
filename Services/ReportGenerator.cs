using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public IPriceCalculator priceCalculator { get; set; }

        public StoreRules storeRules { get; set; }

        public ReportGenerator(IPriceCalculator priceCalculator, StoreRules storeRules)
        {
            this.priceCalculator = priceCalculator;
            this.storeRules = storeRules;   
        }

        public string reportPrice(Product product)
        {
            PriceBreakdown priceBreakdown = priceCalculator.CalculatePrice(product);

            string currency = storeRules.Currecny;

            List<string> reportList = new();

            reportList.Add($"Tax amount = {Rounding.ForReport(priceBreakdown.Tax)} {currency},");

            if (priceBreakdown.PreTaxDiscount != null)
            {
                reportList.Add($"Pre Tax Discount amount = {Rounding.ForReport((double)priceBreakdown.PreTaxDiscount)} {currency},");
            }

            if (priceBreakdown.TotalDiscount != null)
            {
                reportList.Add($"Total Discounts amount = {Rounding.ForReport((double)priceBreakdown.TotalDiscount)} {currency},");
            }

            if(priceBreakdown.AdditionalCostsResults.Count != 0)
            {
                foreach (var cost in priceBreakdown.AdditionalCostsResults)
                {
                    reportList.Add($"{cost.Name} Cost = {Rounding.ForReport(cost.Cost)} {currency},");
                }
            }

            reportList.Add($"Price before = {Rounding.ForReport(priceBreakdown.ProductPrice)} {currency},");

            reportList.Add($"price after = {Rounding.ForReport(priceBreakdown.FinalPrice)} {currency}");

            return string.Join(Environment.NewLine, reportList.ToArray());
        }
    }
}
