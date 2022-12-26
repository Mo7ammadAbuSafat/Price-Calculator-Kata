using Price_Calculator_Kata.Models;
using Price_Calculator_Kata.Enums;

namespace Price_Calculator_Kata.Services
{
    public class AdditionalCostsCalculator : IAdditionalCostsCalculator
    {
        private StoreRules storeRules { get; set; }

        public AdditionalCostsCalculator(StoreRules storeRules)
        {
            this.storeRules = storeRules;
        }

        public AdditionalCostItemResult CalculateAdditionalCostResult(AdditionalCostItem additionalCostItem, Product product)
        {
            AdditionalCostItemResult additionalCostResult;
            if (additionalCostItem.Type == TypeValue.PERCENTAGE)
            {
                additionalCostResult = new()
                {
                    Name = additionalCostItem.Name,
                    Cost = Math.Round(additionalCostItem.Cost * product.Price, 2),
                };
            }
            else
            {
                additionalCostResult = new()
                {
                    Name = additionalCostItem.Name,
                    Cost = additionalCostItem.Cost
                };
            }
            return additionalCostResult;
        }

        public double CalculateTotalCost(List<AdditionalCostItemResult> listCosts)
        {
            double totalCost = 0;
            foreach (var additionalCostResult in listCosts)
            {
                totalCost = Math.Round(totalCost + additionalCostResult.Cost, 2);
            }
            return totalCost;
        }
        public AdditionalCostsBreakdown CalculateAdditionalCosts(Product product)
        {
            if (storeRules.AdditionalCosts.Count == 0)
            {
                return null;
            }
            List<AdditionalCostItemResult> listCosts = new();
            foreach (var additionalCostItem in storeRules.AdditionalCosts)
            {
                listCosts.Add(CalculateAdditionalCostResult(additionalCostItem, product));
            }

            AdditionalCostsBreakdown additionalCostsBreakdown = new()
            {
                additionalCostResults = listCosts,
                totalCost = CalculateTotalCost(listCosts)
            };
            return additionalCostsBreakdown;
        }
    }
}
