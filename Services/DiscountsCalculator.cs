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
                return Rounding.ForCalculation(storeRules.specialDiscount.Percentage * price);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount(double price)
        {
            if (storeRules.universalDiscount == null)
                return 0;
            return Rounding.ForCalculation(storeRules.universalDiscount.Percentage * price);
        }

        public double? CalculatePreTaxDiscount(Product product)
        {
            double PreTaxDiscount = 0;
            if (storeRules.universalDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Rounding.ForCalculation(PreTaxDiscount + CalculateUniversalDiscount(product.Price));
            }
            if (storeRules.specialDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Rounding.ForCalculation(PreTaxDiscount + CalculateSpecialDiscount(product, product.Price - PreTaxDiscount));
            }

            return PreTaxDiscount == 0 ? null : PreTaxDiscount;
        }

        public double CalculateTotalDiscount(Product product)
        {
            double TotalDiscount = 0;
            if(storeRules.CombiningDiscountsType == MethodsOfCombiningDiscounts.ADDITIVE)
            {
                TotalDiscount = Rounding.ForCalculation(CalculateSpecialDiscount(product, product.Price) + CalculateUniversalDiscount(product.Price));
            }
                
            if(storeRules.CombiningDiscountsType == MethodsOfCombiningDiscounts.MULTIPLICATION)
            {
                double firstDiscount = CalculateUniversalDiscount(product.Price);
                double priceAfterFirstDiscount = Rounding.ForCalculation(product.Price - firstDiscount);
                double secoundDiscount = CalculateSpecialDiscount(product, priceAfterFirstDiscount);
                TotalDiscount = Rounding.ForCalculation(firstDiscount + secoundDiscount);
            }
            return TotalDiscount;   
        }

        

        public double? ApplyCapToDiscountAmount(double cap, double? discountAmount)
        {

            if (discountAmount == null)
            {
                return null;
            }

            if(discountAmount > cap)
            {
                return cap;
            }
            return discountAmount;
        }

        public double? CalculateCapAmount(Product product)
        {
            if (storeRules.cap == null)
            {
                return null;
            }
            if (storeRules.cap.Type == RuleType.PERCENTAGE)
            {
                return Math.Round(product.Price * storeRules.cap.Value, 2);
            }
            return storeRules.cap.Value;
        }

        public DiscountsBreakdown CalculateDiscounts(Product product)
        {
            double? PreTaxDiscount = CalculatePreTaxDiscount(product);
            double TotalDiscount = CalculateTotalDiscount(product);
            double? capAmount = CalculateCapAmount(product);
            if (capAmount != null)
            {
                PreTaxDiscount = ApplyCapToDiscountAmount((double)capAmount, PreTaxDiscount);
                TotalDiscount = (double)ApplyCapToDiscountAmount((double)capAmount, TotalDiscount);
            }
            

            DiscountsBreakdown discountsBreakdown = new()
            {
                PreTaxDiscount = CalculatePreTaxDiscount(product),
                TotalDiscount = CalculateTotalDiscount(product)
            };
            return discountsBreakdown;
        }
    }
}
