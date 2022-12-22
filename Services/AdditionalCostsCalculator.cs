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

        public AdditionalCostItemResult CalculateAdditionalCostResult(AdditionalCostItem AC, Product product)
        {
            AdditionalCostItemResult additionalCostResult;
            if (AC.Type == CostType.Percentage)
            {
                additionalCostResult = new()
                {
                    Name = AC.Name,
                    Cost = Math.Round(AC.Cost * product.Price, 2),
                };
            }
            else
            {
                additionalCostResult = new()
                {
                    Name = AC.Name,
                    Cost = AC.Cost
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
            foreach (var AC in storeRules.AdditionalCosts)
            {
                listCosts.Add(CalculateAdditionalCostResult(AC, product));
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
