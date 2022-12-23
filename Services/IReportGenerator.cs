using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface IReportGenerator
    {
        public string reportPrice(Product product);
    }
}
