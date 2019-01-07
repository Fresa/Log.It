using FakeItEasy;

namespace Log.It.Tests
{
    public class FakeLoggerFactory
    {
        private static readonly object InitializationLock = new object();

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
            lock (InitializationLock)
            {
                if (LogFactory.HasFactory)
                {
                    return;
                }

                LogFactory.Initialize(new FakeLoggerFactory().Create());
            }
        }
    }
}