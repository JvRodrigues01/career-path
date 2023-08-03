using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings.Admin
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.Property(x => x.Username)
                .IsRequired()
                .HasColumnName("Username")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.LastLogin)
                .IsRequired(false)
                .HasColumnName("LastLogin")
                .HasColumnType("SMALLDATETIME");

            builder.Property(x => x.HashedPassword)
                .IsRequired()
                .HasColumnName("HashedPassword")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(280);

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
        }
    }
}
