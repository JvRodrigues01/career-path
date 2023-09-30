using AutoMapper;
using Moq;
using Moq.AutoMock;

namespace Api.Tests
{
    public class BaseTest : IClassFixture<ApiFixure>
    {
        private readonly AutoMocker _autoMocker;
        public BaseTest(ApiFixure fixure)
        {
            _autoMocker = fixure.AutoMocker;
            ResetMockCalls();
        }

        public void AddMapper() => _autoMocker.Use<IMapper>(Mapper);

        public T GetService<T>() where T : class
            => _autoMocker.CreateInstance<T>();

        public Mock<T> GetMock<T>() where T : class
            => _autoMocker.GetMock<T>();

        private void ResetMockCalls()
        {
            foreach (var resolvedObject in _autoMocker.ResolvedObjects)
                (resolvedObject.Value as Mock)?.Invocations.Clear();
        }

        protected IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Services");
        }).CreateMapper();
    }
}
