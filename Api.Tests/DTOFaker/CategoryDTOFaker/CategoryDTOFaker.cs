using Domain.Dtos.Admin;

namespace Api.Tests.DTOFaker.CategoryDTOFaker
{
    public class CategoryDTOFaker : ObjectFaker<CategoryDTO>
    {
        public CategoryDTOFaker() 
        {
            UsePrivateConstructor()
                .RuleFor(c => c.Name, c => c.Name.FullName())
                .RuleFor(x => x.Description, c => c.Lorem.Paragraph())
                .RuleFor(x => x.IsEnabled, true)
                .RuleFor(x => x.CreatedAt, DateTime.Now)
                .RuleFor(x => x.UpdatedAt, DateTime.Now);
        }
    }
}
