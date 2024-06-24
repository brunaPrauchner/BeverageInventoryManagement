using BeverageInventoryManagement.Data;
using BeverageInventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BeverageInventoryManagement.Services
{
    public class BeverageService : IBeverageService
    {
        private readonly BeverageDbContext _context;
        public BeverageService(BeverageDbContext context) 
        {
              _context = context;
        }

        public async Task<IEnumerable<Beverage>> GetAllBeveragesAsync()
        {
            return await _context.Beverages.ToListAsync();
        }

        public async Task<Beverage?> GetBeverageAsync (long beverageId)
        {
            return await _context.Beverages.FindAsync(beverageId);
        }
        public async Task<Beverage> AddBeverageAsync(Beverage beverage)
        {
            _context.Beverages.Add(beverage);
            await _context.SaveChangesAsync();
            return beverage;
        }
        public async Task<Beverage> UpdateBeverageAsync(long beverageId, Beverage beverage)
        {
            var existingBeverage = await _context.Beverages.FindAsync(beverageId) ?? throw new Exception("Beverage does not exist!");

            existingBeverage.Name = beverage.Name;
            existingBeverage.Type = beverage.Type;
            existingBeverage.Stock = beverage.Stock;
            existingBeverage.Price = beverage.Price;

            await _context.SaveChangesAsync();
            return existingBeverage;
        }
        public async Task<bool> DeleteBeverageAsync(long beverageId)
        {
            var beverage = await _context.Beverages.FindAsync(beverageId);
            if (beverage == null) { return false; }
            _context.Beverages.Remove(beverage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}
