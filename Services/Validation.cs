using Price_Calculator_Kata.Enums;
using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public class Validation : IValidation
    {
        public void CheckPercentageValidation(double percentage, string percentageName)
        {
            if (percentage < 0 || percentage > 1)
            {
                throw new ArgumentException($"{percentageName} percentage must be between 0 and 1.");
            }
        }

        public void CheckCostValueValidation(double costAmount, string CostName)
        {
            if (costAmount < 0 )
            {
                throw new ArgumentException($"{CostName} Value must be greater than 0 .");
            }
        }

        public void CheckAdditionalCostsValidation(List<AdditionalCostItem> AdditionalCosts)
        {
            foreach (var CostItem in AdditionalCosts)
            {
                if(CostItem.Type== TypeValue.PERCENTAGE)
                {
                    CheckPercentageValidation(CostItem.Cost, CostItem.Name);
                }
                else if(CostItem.Type == TypeValue.ABSOLUTE_VALUE)
                {

                }
            }

        }

        public void CheckPriceValidation(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be a negative value.");
            }
        }

        public void CheckUPCValidation(int? UPC)
        {
            if (UPC == null )
            {
                throw new ArgumentNullException("UPC cannot be a null value.");
            }
        }

        public void CheckProductValidation(Product product)
        {
            CheckPriceValidation(product.Price);
            CheckUPCValidation(product.UPC);
        }

        public void CheckStoreRolesValidation(StoreRules storeRules)
        {
            CheckPercentageValidation(storeRules.TaxPercentage, "Tax Percentage");
            if(storeRules.specialDiscount != null)
            {
                CheckPercentageValidation(storeRules.specialDiscount.Percentage, "Special Discount");
            }
            if (storeRules.universalDiscount != null)
            {
                CheckPercentageValidation(storeRules.universalDiscount.Percentage, "Universal Discount");
            }
            CheckAdditionalCostsValidation(storeRules.AdditionalCosts);
            
        }
    }
}
