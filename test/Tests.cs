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

    public class CsvLoaderTests
    {
        // https://github.com/dennisdoomen/fluentassertions/wiki
        [Fact]
        public void LoadMockedResource_Test() 
        {
            new Rates().Show();
            Assert.True(true);


            var mock = new Mock<IFakeFileSource>();
            mock.Setup(m => m.Read()).Returns("Alex,101,55.5");
            Console.WriteLine(mock.Object.Read());
            mock.Object.Read().Should().Be("Alex,101,55.5");
        }
    }

    public class CalcTests
    {
        [Fact]
        public void Test1() 
        {
            new Rates().Show();
            Assert.True(true);
        }
    }
}
