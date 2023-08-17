namespace Domain.Entities.Admin
{
    public class Category
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsEnabled { get; set; } = true;
        public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
