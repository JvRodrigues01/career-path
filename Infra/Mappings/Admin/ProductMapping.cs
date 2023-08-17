using Domain.Entities.Admin;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Infra.Mappings.Admin
{
    public class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping() 
        {
            Id(x => x.Id, b =>
            {
                b.Column("Id");
            });

            Property(x => x.Name, b =>
            {
                b.Length(50);
                b.Type(NHibernateUtil.String);
                b.NotNullable(true);
                b.Column("Name");
            });

            Property(x => x.Description, b =>
            {
                b.Length(280);
                b.Type(NHibernateUtil.String);
                b.NotNullable(true);
                b.Column("Description");
            });

            Property(x => x.Price, b =>
            {
                b.Type(NHibernateUtil.Double);
                b.Scale(2);
                b.Precision(10);
                b.NotNullable(true);
                b.Column("Price");
            });

            Property(x => x.StockQuantity, b =>
            {
                b.Type(NHibernateUtil.Int64);
                b.NotNullable(true);
                b.Column("StockQuantity");
            });

            Property(x => x.IsEnabled, b =>
            {
                b.NotNullable(true);
                b.Column("IsEnabled");
            });

            Property(x => x.CreatedAt, b =>
            {
                b.Column("CreatedAt");
                b.NotNullable(true);
                b.Type(NHibernateUtil.DateTime);
            });

            Property(x => x.UpdatedAt, b =>
            {
                b.Column("UpdatedAt");
                b.NotNullable(true);
                b.Type(NHibernateUtil.DateTime);
            });

            ManyToOne(x => x.Category, map =>
            {
                map.Column("IdCategory");
                map.Cascade(Cascade.None);
            });

            Table("Product");
        }
    }
}
