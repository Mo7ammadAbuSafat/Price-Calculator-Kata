using Price_Calculator_Kata.Models;
using Price_Calculator_Kata.Enums;

namespace Price_Calculator_Kata.Services
{
    public class DiscountsCalculator : IDiscountCalculator
    {
        private StoreRules storeRules { get; set; }
        
        public DiscountsCalculator(StoreRules storeRules)
        {
            this.storeRules = storeRules;
        }

        public double CalculateSpecialDiscount(Product product, double price)
        {
            if (storeRules.specialDiscount == null) return 0;
            if (product.UPC == storeRules.specialDiscount.UPC)
            {
                return Math.Round(storeRules.specialDiscount.Percentage * price, 2);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount(double price)
        {
            if (storeRules.universalDiscount == null)
                return 0;
            return Math.Round(storeRules.universalDiscount.Percentage * price, 2);
        }

        public double? CalculatePreTaxDiscount(Product product)
        {
            double PreTaxDiscount = 0;
            if (storeRules.universalDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateUniversalDiscount(product.Price), 2);
            }
            if (storeRules.specialDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateSpecialDiscount(product, product.Price - PreTaxDiscount), 2);
            }

            return PreTaxDiscount == 0 ? null : PreTaxDiscount;
        }

        public double CalculateTotalDiscount(Product product)
        {
            double TotalDiscount = 0;
            if(storeRules.CombiningDiscountsType == MethodsOfCombiningDiscounts.ADDITIVE)
            {
                TotalDiscount = Math.Round(CalculateSpecialDiscount(product, product.Price) + CalculateUniversalDiscount(product.Price), 2);
            }
                
            if(storeRules.CombiningDiscountsType == MethodsOfCombiningDiscounts.MULTIPLICATION)
            {
                double firstDiscount = CalculateUniversalDiscount(product.Price);
                double priceAfterFirstDiscount = Math.Round(product.Price - firstDiscount, 2);
                double secoundDiscount = CalculateSpecialDiscount(product, priceAfterFirstDiscount);
                TotalDiscount = Math.Round(firstDiscount + secoundDiscount, 2);
            }
            return TotalDiscount;   
        }

        public DiscountsBreakdown CalculateDiscounts(Product product)
        {
            DiscountsBreakdown discountsBreakdown = new()
            {
                PreTaxDiscount = CalculatePreTaxDiscount(product),
                TotalDiscount = CalculateTotalDiscount(product)
            };
            return discountsBreakdown;
        }
    }
}
