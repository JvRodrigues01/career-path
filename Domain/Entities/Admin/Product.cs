namespace Domain.Entities.Admin
{
    public class Product
    {
        public virtual Guid Id { get; protected set; } = Guid.NewGuid();
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int StockQuantity { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual Guid IdCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
