using FakeItEasy;
using Given_a_app_configured_logger_factory;

namespace Log.It.Tests
{
    public class FakeLoggerFactory : ILoggerFactory
    {
        public ILogFactory Create()
        {
            var factory = A.Fake<ILogFactory>();
            A.CallTo(() => factory.Create<When_creating_a_logger>())
                .ReturnsLazily(() => new FakeLogger());
            A.CallTo(() => factory.Create())
                .ReturnsLazily(() => new FakeLogger());
            return factory;
        }
    }
}