namespace Domain.Dtos.Admin
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsEnabled { get; set; } = true;
        public Guid IdCategory { get; set; }
    }
}
