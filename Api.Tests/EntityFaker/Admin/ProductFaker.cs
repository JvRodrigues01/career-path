using Bogus;
using Domain.Entities.Admin;

namespace Api.Tests.EntityFaker.Admin
{
    public class ProductFaker : ObjectFaker<Product>
    {
        public ProductFaker() 
        {
            var categoryFaker = new ObjectFaker<Category>().UsePrivateConstructor().Generate();

            UsePrivateConstructor()
                .RuleFor(x => x.Id, new Guid())
                .RuleFor(x => x.Name, c => c.Name.FullName())
                .RuleFor(x => x.Description, c => c.Lorem.Paragraph())
                .RuleFor(x => x.Price, c => c.Random.Decimal())
                .RuleFor(x => x.StockQuantity, c => c.Random.Int(0, 1000))
                .RuleFor(x => x.IdCategory, categoryFaker.Id)
                .RuleFor(x => x.Category, categoryFaker)
                .RuleFor(x => x.IsEnabled, true)
                .RuleFor(x => x.CreatedAt, DateTime.Now)
                .RuleFor(x => x.UpdatedAt, DateTime.Now);
        }
    }
}
