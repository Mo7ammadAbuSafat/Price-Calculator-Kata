namespace Price_Calculator_Kata
{
    public class DiscountsCalculator
    {

        public StoreRules storeRules;
        public Product product;

        public DiscountsCalculator(StoreRules storeRules, Product product)
        {
            this.storeRules = storeRules;
            this.product = product;
        }

        public double CalculateSpecialDiscount()
        {
            if (storeRules.getSpecialDiscount() == null) return 0;
            if (product.UPC == storeRules.getSpecialDiscount().UPC)
            {
                return Math.Round(storeRules.getSpecialDiscount().Percentage * product.Price, 2);
            }
            else return 0;
        }

        public double CalculateUniversalDiscount()
        {
            if (storeRules.getUniversalDiscount() == null)
                return 0;
            return Math.Round(storeRules.getUniversalDiscount().Percentage * product.Price, 2);
        }

        public double? CalculatePreTaxDiscount()
        {
            double PreTaxDiscount = 0;
            if (storeRules.getUniversalDiscount()?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateUniversalDiscount(), 2);
            }
            if (storeRules.getSpecialDiscount()?.Type == DiscountType.PRE_TAX)
            {
                PreTaxDiscount = Math.Round(PreTaxDiscount + CalculateSpecialDiscount(), 2);
            }

            return PreTaxDiscount == 0 ? null : PreTaxDiscount;
        }

        public double? CalculatePostTaxDiscount()
        {
            double PostTaxDiscount = 0;
            if (storeRules.getUniversalDiscount()?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateUniversalDiscount(), 2);
            }
            if (storeRules.getSpecialDiscount()?.Type == DiscountType.POST_TAX)
            {
                PostTaxDiscount = Math.Round(PostTaxDiscount + CalculateSpecialDiscount(), 2);
            }

            return PostTaxDiscount == 0 ? null : PostTaxDiscount;
        }

        public double CalculateTotalDiscount()
        {
            return Math.Round(CalculateSpecialDiscount() + CalculateUniversalDiscount(), 2);
        }
    }
}
