using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface IPriceCalculator
    {
        public PriceBreakdown CalculatePrice(Product product);
    }
}
