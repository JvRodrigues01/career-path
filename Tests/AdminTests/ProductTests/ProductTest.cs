using Tests.DTOFaker.ProductDTOFaker;
using Tests.EntityFaker.Admin;
using Domain.Entities.Admin;
using Domain.Exceptions;
using FluentAssertions;
using Infra.Repository.Admin;
using Moq;
using Services.Admin;

namespace Tests.AdminTests.ProductTests
{
    public class ProductTest : BaseTest
    {
        private readonly IProductService _productService;
        public ProductTest(ApiFixure fixture) : base(fixture)
        {
            AddMapper();
            _productService = GetService<ProductService>();
        }

        [Fact]
        public async Task Test_Create()
        {
            var productDto = new ProductDTOFaker().Generate();

            var product = new ProductFaker().Generate();

            GetMock<IGenericRepository<Product>>().Setup(x => x.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productService.Create(productDto);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Update()
        {
            var productDto = new ProductDTOFaker().Generate();

            var product = new ProductFaker().Generate();

            GetMock<IGenericRepository<Product>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
            GetMock<IGenericRepository<Product>>().Setup(x => x.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productService.Update(It.IsAny<Guid>(), productDto);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Update_Not_Found()
        {
            var productDto = new ProductDTOFaker().Generate();

            var product = new ProductFaker().Generate();

            GetMock<IGenericRepository<Product>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as Product);

            Func<Task> action = async () =>
            {
                await _productService.Update(It.IsAny<Guid>(), productDto);
            };

            await action.Should().ThrowAsync<BadRequestException>();
        }

        [Fact]
        public async Task Test_Delete()
        {
            var product = new ProductFaker().Generate();

            GetMock<IGenericRepository<Product>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
            GetMock<IGenericRepository<Product>>().Setup(x => x.DeleteAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productService.Delete(It.IsAny<Guid>());

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Delete_Not_Found()
        {
            GetMock<IGenericRepository<Product>>().Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as Product);

            Func<Task> action = async () =>
            {
                await _productService.Delete(It.IsAny<Guid>());
            };

            await action.Should().ThrowAsync<BadRequestException>();
        }

        [Fact]
        public async Task Test_List()
        {
            var products = new ProductFaker().Generate(10);

            GetMock<IGenericRepository<Product>>().Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            var result = await _productService.List();

            result.Should().NotBeNull();
            result.Count().Should().Be(products.Count());
        }
    }
}