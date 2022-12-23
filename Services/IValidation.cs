
using Price_Calculator_Kata.Models;

namespace Price_Calculator_Kata.Services
{
    public interface IValidation
    {
        public void CheckProductValidation(Product product);
        public void CheckStoreRolesValidation(StoreRules storeRules);
    }
}
