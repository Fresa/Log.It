using Log.It;
using Log.It.Tests;
using Should.Fluent;
using Test.It.With.XUnit;
using Xunit;

namespace Given_a_app_configured_logger_factory
{
    public class When_creating_a_logger_specifying_a_class : XUnit2Specification
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

    public class When_creating_a_logger : XUnit2Specification
    {
        private ILogger _createdLogger;

        protected override void When()
        {
            _createdLogger = LogFactory.Create();
        }

        [Fact]
        public void It_should_create_a_fake_logger()
        {
            _createdLogger.Should().Be.OfType<FakeLogger>();
        }

        [Fact]
        public void It_should_create_a_logger_with_the_name_of_the_creating_class()
        {
            ((FakeLogger) _createdLogger).Name.Should().Equal("Given_a_app_configured_logger_factory.When_creating_a_logger");
        }
    }
}