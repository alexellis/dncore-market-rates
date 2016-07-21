using System;
using Xunit;
using RateCalc.Engine;
using FluentAssertions;
using Moq;

namespace RateCalc.Engine.Test
{
    public interface IFakeFileSource {
        string Read();
    }

    public class ExploratoryMoqTests
    {
        // https://github.com/dennisdoomen/fluentassertions/wiki
        [Fact]
        public void LoadMockedResource_Test() 
        {
            var mock = new Mock<IFakeFileSource>();
            mock.Setup(m => m.Read()).Returns("Alex,101,55.5");
            mock.Object.Read().Should().Be("Alex,101,55.5");
        }
    }
}
