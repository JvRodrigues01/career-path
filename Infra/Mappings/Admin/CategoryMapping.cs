using Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings.Admin
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
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

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.IdCategory);
        }
    }
}
