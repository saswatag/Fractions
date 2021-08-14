using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;
using FractionOperation;

namespace FractionTests
{
    public class ReduceFractionTests
    {
        [Fact]
        public void ReduceFractionNotInLowestTerms()
        {
            Fraction reducedFraction = new GCDFractionReducer().Reduce(new Fraction(4, 8));
            reducedFraction.Should().Be(new Fraction(1, 2));
        }
    }
}
