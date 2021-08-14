using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;
using FractionOperation;
using System.Reflection.Metadata.Ecma335;

namespace FractionTests
{
    public class ReduceFractionTests
    {
        [Fact]
        public void ReduceFractionNotInLowestTerms()
        {
            Fraction reducedFraction = new GCDFractionReducer().Reduce(AnyUnReducedFractionAndTheCorrespondingReducedForm().UnReducedFraction);
            reducedFraction.Should().Be(AnyUnReducedFractionAndTheCorrespondingReducedForm().ExpectedReducedFraction);
        }

        [Fact]
        public void ReduceFractionAreadyInLowestTerms()
        {
            Fraction fractioInLowestTerms = AnyFractionInLowestTerms();

            Fraction reducedFraction = new GCDFractionReducer().Reduce(fractioInLowestTerms);
            reducedFraction.Should().Be(fractioInLowestTerms);
        }

        [Fact]
        public void ReduceFractionThatIsZero()
        {
            Fraction reducedFraction = new GCDFractionReducer().Reduce(new Fraction(0, 6));
            reducedFraction.Should().Be(new Fraction(0, 6));
        }

        #region Helpers

        private (Fraction UnReducedFraction, Fraction ExpectedReducedFraction) AnyUnReducedFractionAndTheCorrespondingReducedForm() => 
            (UnReducedFraction: new Fraction(4, 8), ExpectedReducedFraction: new Fraction(1, 2));

        private Fraction AnyFractionInLowestTerms() => new Fraction(3, 5);

        #endregion
    }
}
