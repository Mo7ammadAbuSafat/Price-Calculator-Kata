using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface IDiscountCalculator
    {
        public DiscountsBreakdown CalculateDiscounts(Product product);
    }
}
