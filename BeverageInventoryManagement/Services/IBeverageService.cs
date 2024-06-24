using BeverageInventoryManagement.Models;

namespace BeverageInventoryManagement.Services
{
    public interface IBeverageService
    {
        Task<IEnumerable<Beverage>> GetAllBeveragesAsync();
        Task<Beverage?> GetBeverageAsync(long beverageId);
        Task<Beverage> AddBeverageAsync(Beverage beverage);
        Task<Beverage> UpdateBeverageAsync(long beverageId, Beverage beverage);
        Task<bool> DeleteBeverageAsync(long beverageId);
    }
}
