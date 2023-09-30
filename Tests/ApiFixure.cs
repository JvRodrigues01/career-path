using Moq.AutoMock;

namespace Tests
{
    public class ApiFixure : IDisposable
    {
        public AutoMocker AutoMocker { get; private set; }
        public ApiFixure()
        {
            AutoMocker = new AutoMocker();
        }

        public void Dispose()
        {
            AutoMocker.AsDisposable().Dispose();
        }
    }
}
