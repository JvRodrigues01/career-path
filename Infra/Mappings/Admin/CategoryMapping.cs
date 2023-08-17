using Domain.Entities.Admin;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Infra.Mappings.Admin
{
    public class CategoryMapping : ClassMapping<Category>
    {
        public CategoryMapping() 
        {
            Id(x => x.Id, b =>
            {
                b.Generator(Generators.Increment);
                b.Type(NHibernateUtil.Int64);
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

            Property(x => x.IsEnabled, b =>
            {
                b.Type(NHibernateUtil.Byte);
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

            Table("Category");
        }
    }
}
