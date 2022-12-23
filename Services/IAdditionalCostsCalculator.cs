using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface IAdditionalCostsCalculator
    {
        public AdditionalCostsBreakdown CalculateAdditionalCosts(Product product);
    }
}
