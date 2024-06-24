using BeverageInventoryManagement.Models;
using BeverageInventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeverageInventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageService _beverageService; 
        public BeverageController(IBeverageService beverageService) 
        {
            _beverageService = beverageService;
        }

        [HttpGet("{beverageId}")]
        public async Task<ActionResult<Beverage>> GetBeverage(long beverageId)
        {
            var beverage = await _beverageService.GetBeverageAsync(beverageId);
            
            if (beverage == null)
            {
                return NotFound();
            }
            return Ok(beverage);
        }

        [HttpGet("listbeverages")]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages()
        {
            var allBeverages = await _beverageService.GetAllBeveragesAsync();
            return Ok(allBeverages);
        }

        [HttpPost("createBeverage")]
        public async Task<ActionResult<Beverage>> CreateBeverage([FromBody] Beverage beverage)
        {
            var createdBeverage = await _beverageService.AddBeverageAsync(beverage);
            return Ok(createdBeverage);
        }

        [HttpPut("updateBeverage/{beverageId}")]
        public async Task<ActionResult> UpdateBeverage(long beverageId, [FromBody] Beverage beverage)
        {
            var updatedBeverage = await _beverageService.UpdateBeverageAsync(beverageId, beverage);

            if (updatedBeverage == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("deleteBeverage/{beverageId}")]
        public async Task<ActionResult> DeleteBeverage(long beverageId)
        {
            var result = await _beverageService.DeleteBeverageAsync(beverageId);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
