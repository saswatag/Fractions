using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;

namespace FractionTests
{
    public class ReduceFractionTests
    {
        [Fact (Skip = "Waiting for reduce to work")]
        public void FractionsWithDenominatorOneAreInitializedOnlyWithNumerator()
        {
            var fraction = new Fraction(4, 8);
            fraction.Should().Be(new Fraction(1, 2));
        }
    }
}
