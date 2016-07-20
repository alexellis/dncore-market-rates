using System;
using Xunit;
using RateCalc.Engine;

namespace RateCalc.Engine.Test
{
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
