using FakeItEasy;

namespace Log.It.Tests
{
    public class FakeLoggerFactory
    {
        public ILogFactory Create()
        {
            var factory = A.Fake<ILogFactory>();
            A.CallTo(() => factory.Create(A<string>.Ignored))
                .ReturnsLazily((string name) => new FakeLogger(name));
            A.CallTo(() => factory.Create<FakeLoggerFactory>())
                .ReturnsLazily(() => new FakeLogger(nameof(FakeLoggerFactory)));
            return factory;
        }

        internal static void InitializeOnce()
        {
            if (LogFactory.HasFactory)
            {
                return;
            }

            LogFactory.Initialize(new FakeLoggerFactory().Create());
        }
    }
}