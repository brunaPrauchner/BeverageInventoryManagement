using BeverageInventoryManagement.Data;
using BeverageInventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BeverageInventoryManagement.Services.Test
{
    public class BeverageServiceTests
    {
        private readonly BeverageService _beverageService;
        private readonly Mock<BeverageDbContext> _mockContext;
        private readonly Mock<DbSet<Beverage>> _mockSet;

        public BeverageServiceTests()
        {
            _mockContext = new Mock<BeverageDbContext>();
            _mockSet = new Mock<DbSet<Beverage>>();

            _mockContext.Setup(m => m.Beverages).Returns(_mockSet.Object);
            _beverageService = new BeverageService(_mockContext.Object);
        }
        [Fact]
        public async Task GetAllBeveragesAsync_ShouldReturnAllBeverages()
        {
            //Arrange
            var beverages = new List<Beverage>
            {
                new Beverage { BeverageId = 1, Name = "Red Wine" },
                new Beverage { BeverageId = 2, Name = "White Wine" }
            }.AsQueryable();

            _mockSet.As<IQueryable<Beverage>>().Setup(m => m.Provider).Returns(beverages.Provider);
            _mockSet.As<IQueryable<Beverage>>().Setup(m => m.Expression).Returns(beverages.Expression);
            _mockSet.As<IQueryable<Beverage>>().Setup(m => m.ElementType).Returns(beverages.ElementType);
            _mockSet.As<IQueryable<Beverage>>().Setup(m => m.GetEnumerator()).Returns(beverages.GetEnumerator());

            // Act
            var result = await _beverageService.GetAllBeveragesAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }



    }
}
