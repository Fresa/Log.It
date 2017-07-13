using Should.Fluent;
using Test.It.With.XUnit;
using Xunit;

namespace Log.It.Tests
{
    public class When_creating_a_logger : XUnit2Specification
    {
        private ILogger _createdLogger;
        
        protected override void When()
        {
            _createdLogger = LogFactory.Create<When_creating_a_logger>();
        }
        
        [Fact]
        public void It_should_create_a_fake_logger()
        {
            _createdLogger.Should().Be.OfType<FakeLogger>();
        }
    }
}