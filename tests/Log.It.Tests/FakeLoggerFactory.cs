using FakeItEasy;
using Given_a_app_configured_logger_factory;

namespace Log.It.Tests
{
    public class FakeLoggerFactory : ILoggerFactory
    {
        public ILogFactory Create()
        {
            var factory = A.Fake<ILogFactory>();
            A.CallTo(() => factory.Create(A<string>.Ignored))
                .ReturnsLazily((string name) => new FakeLogger(name));
            A.CallTo(() => factory.Create<When_creating_a_logger>())
                .ReturnsLazily(() => new FakeLogger(nameof(When_creating_a_logger)));
            return factory;
        }
    }
}