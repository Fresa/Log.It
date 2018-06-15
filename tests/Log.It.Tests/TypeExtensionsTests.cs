using System;
using Log.It;
using Log.It.Tests;
using Should.Fluent;
using Test.It.With.XUnit;
using Xunit;

namespace Given_a_generic_type
{
    public class When_getting_pretty_name : XUnit2Specification
    {
        private string _name;
        private Type _type;

        protected override void Given()
        {
            _type = typeof(Generic<string, Guid>);
        }

        protected override void When()
        {
            _name = _type.GetPrettyName();
        }

        [Fact]
        public void It_should_return_a_prettified_name()
        {
            _name.Should().Equal("Log.It.Tests.Generic<System.String, System.Guid>");
        }
    }
}

namespace Given_a_type
{
    public class When_getting_pretty_name : XUnit2Specification
    {
        private string _name;
        private Type _type;

        protected override void Given()
        {
            _type = typeof(Guid);
        }

        protected override void When()
        {
            _name = _type.GetPrettyName();
        }

        [Fact]
        public void It_should_return_a_prettified_name()
        {
            _name.Should().Equal("System.Guid");
        }
    }
}