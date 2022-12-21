using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata
{
    public class DiscountsCalculator
    {
        public StoreRules storeRules { get; set; }
        public double CalculateSpecialDiscount(Product product)
        {
            if (storeRules.specialDiscount == null) return 0;
            if (product.UPC == storeRules.specialDiscount.UPC)
            {
                return Math.Round(storeRules.specialDiscount.Percentage * product.Price, 2);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount(Product product)
        {
            if (storeRules.universalDiscount == null)
                return 0;
            return Math.Round(storeRules.universalDiscount.Percentage * product.Price, 2);
        }

        public double? CalculatePreTaxDiscount(Product product)
        {
            double PreTaxDiscount = 0;
            if (storeRules.universalDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateUniversalDiscount(product), 2);
            }
            if (storeRules.specialDiscount?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateSpecialDiscount(product), 2);
            }

            return PreTaxDiscount == 0 ? null : PreTaxDiscount;
        }

        public double? CalculatePostTaxDiscount(Product product)
        {
            double PostTaxDiscount = 0;
            if (storeRules.universalDiscount?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateUniversalDiscount(product), 2);
            }
            if (storeRules.specialDiscount?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateSpecialDiscount(product), 2);
            }

            return PostTaxDiscount == 0 ? null : PostTaxDiscount;
        }

        public double CalculateTotalDiscount(Product product)
        {
            return Math.Round(CalculateSpecialDiscount(product) + CalculateUniversalDiscount(product), 2);
        }

        public DiscountsBreakdown CalculateDiscounts(Product product)
        {
            DiscountsBreakdown discountsBreakdown = new()
            {
                SpecialDiscount =  CalculateSpecialDiscount(product),
                UniversalDiscount = CalculateUniversalDiscount(product),
                PostTaxDiscount= CalculatePostTaxDiscount(product),
                PreTaxDiscount= CalculatePreTaxDiscount(product),
                TotalDiscount= CalculateTotalDiscount(product)
            };
            return discountsBreakdown;
        }
    }
}
