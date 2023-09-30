using Tests.DTOFaker.CategoryDTOFaker;
using Tests.EntityFaker.Admin;
using Domain.Entities.Admin;
using Domain.Exceptions;
using FluentAssertions;
using Infra.Repository.Admin;
using Moq;
using Services.Admin;

namespace Tests.AdminTests.CategoryTests
{
    public class CategoryTests : BaseTest
    {
        private readonly ICategoryService _categoryService;
        public CategoryTests(ApiFixure fixture) : base(fixture)
        {
            AddMapper();
            _categoryService = GetService<CategoryService>();
        }

        [Fact]
        public async Task Test_Create()
        {
            var categoryDto = new CategoryDTOFaker().Generate();

            var category = new CategoryFaker().Generate();

            GetMock<IGenericRepository<Category>>().Setup(x => x.AddAsync(It.IsAny<Category>())).ReturnsAsync(category);

            var result = await _categoryService.Create(categoryDto);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Update()
        {
            var categoryDto = new CategoryDTOFaker().Generate();

            var category = new CategoryFaker().Generate();

            GetMock<IGenericRepository<Category>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(category);
            GetMock<IGenericRepository<Category>>().Setup(x => x.UpdateAsync(It.IsAny<Category>())).ReturnsAsync(category);

            var result = await _categoryService.Update(It.IsAny<Guid>(), categoryDto);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Update_Not_Found()
        {
            var categoryDto = new CategoryDTOFaker().Generate();

            var category = new CategoryFaker().Generate();

            GetMock<IGenericRepository<Category>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as Category);

            Func<Task> action = async () =>
            {
                await _categoryService.Update(It.IsAny<Guid>(), categoryDto);
            };

            await action.Should().ThrowAsync<BadRequestException>();
        }

        [Fact]
        public async Task Test_Delete()
        {
            var categoryDto = new CategoryDTOFaker().Generate();

            var category = new CategoryFaker().Generate();

            GetMock<IGenericRepository<Category>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(category);
            GetMock<IGenericRepository<Category>>().Setup(x => x.DeleteAsync(It.IsAny<Category>())).ReturnsAsync(category);

            var result = await _categoryService.Delete(It.IsAny<Guid>());

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Delete_Not_Found()
        {
            var categoryDto = new CategoryDTOFaker().Generate();

            var category = new CategoryFaker().Generate();

            GetMock<IGenericRepository<Category>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as Category);

            Func<Task> action = async () =>
            {
                await _categoryService.Delete(It.IsAny<Guid>());
            };

            await action.Should().ThrowAsync<BadRequestException>();
        }

        [Fact]
        public async Task Test_List()
        {
            var categories = new CategoryFaker().Generate(10);

            GetMock<IGenericRepository<Category>>().Setup(x => x.GetAllAsync()).ReturnsAsync(categories);

            var result = await _categoryService.List();

            result.Should().NotBeNull();
            result.Count().Should().Be(categories.Count());
        }
    }
}
