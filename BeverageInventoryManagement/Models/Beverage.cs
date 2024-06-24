namespace BeverageInventoryManagement.Models
{
    public class Beverage
    {
        public long BeverageId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
