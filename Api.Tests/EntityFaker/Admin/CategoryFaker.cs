using Domain.Entities.Admin;
using Tests;

namespace Tests.EntityFaker.Admin
{
    public class CategoryFaker : ObjectFaker<Category>
    {
        public CategoryFaker()
        {
            UsePrivateConstructor()
                .RuleFor(x => x.Id, new Guid())
                .RuleFor(c => c.Name, c => c.Name.FullName())
                .RuleFor(x => x.Description, c => c.Lorem.Paragraph())
                .RuleFor(x => x.IsEnabled, true)
                .RuleFor(x => x.CreatedAt, DateTime.Now)
                .RuleFor(x => x.UpdatedAt, DateTime.Now);
        }
    }
}
