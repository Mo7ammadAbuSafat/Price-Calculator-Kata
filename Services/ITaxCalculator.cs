using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface ITaxCalculator
    {
        public double CalculateTax(double ProductPrice);
    }
}
