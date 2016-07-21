using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Xunit;
using RateCalc.Engine;
using FluentAssertions;
using Moq;

namespace RateCalc.Engine.Test
{
    public class LoanProjectorTest
    {
        // Validation could be moved via SRP into separate class. 
        [Fact]
        public void WorkedExampleVerification_Test() {

            var sut = new LoanProjector();
            Projection projection = sut.Get((double)(7.0/100/12), 36, 1000);
            projection.Should().NotBeNull();
            Math.Round(projection.Payment,2).Should().Be(Math.Round(30.8770968653718,2));

            Math.Round(projection.TotalPayable,2).Should().Be(Math.Round(1111.58,2));

        }
    }
}