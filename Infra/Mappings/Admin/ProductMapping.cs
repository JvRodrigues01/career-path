using Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings.Admin
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.StockQuantity)
                .IsRequired()
                .HasColumnName("StockQuantity");

            builder.Property(x => x.IdCategory)
                .IsRequired()
                .HasColumnName("IdCategory");

            builder.Property(x => x.IsEnabled)
                .HasColumnName("IsEnabled")
                .HasColumnType("tinyint");

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("SMALLDATETIME");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName("UpdatedAt")
                .HasColumnType("SMALLDATETIME");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdCategory);
        }
    }
}
