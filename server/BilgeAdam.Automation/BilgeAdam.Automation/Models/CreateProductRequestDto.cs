namespace BilgeAdam.Automation.Models
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }
    }
}
