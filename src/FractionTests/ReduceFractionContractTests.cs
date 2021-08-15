using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;
using FractionOperation;
using FractionOperations.Collaborators;

namespace FractionTests
{
    public abstract class ReduceFractionContractTests
    {
        protected abstract IFractionReducer ProvideFractionReducer();

        [Fact]
        public void ReduceFractionNotInLowestTerms()
        {
            Fraction unreducedFraction = AnyUnReducedFractionAndTheCorrespondingReducedForm().UnReducedFraction;
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(unreducedFraction.Numerator, unreducedFraction.Denominator);

            new Fraction(reduced.ReducedNumerator, reduced.ReducedDenominator).Should().Be(AnyUnReducedFractionAndTheCorrespondingReducedForm().ExpectedReducedFraction);
        }

        [Fact]
        public void ReduceFractionAreadyInLowestTerms()
        {
            Fraction fractioInLowestTerms = AnyFractionInLowestTerms();
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(fractioInLowestTerms.Numerator, fractioInLowestTerms.Denominator);

            new Fraction(reduced.ReducedNumerator, reduced.ReducedDenominator).Should().Be(fractioInLowestTerms);
        }

        [Fact]
        public void ReduceFractionThatIsZero()
        {
            Fraction zeroFraction = AnyFractionThatIsZero();
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(zeroFraction.Numerator, zeroFraction.Denominator);

            new Fraction(reduced.ReducedNumerator, reduced.ReducedDenominator).Should().Be(new Fraction(zeroFraction.Numerator, zeroFraction.Denominator));
        }

        #region Helpers

        private (Fraction UnReducedFraction, Fraction ExpectedReducedFraction) AnyUnReducedFractionAndTheCorrespondingReducedForm() => 
            (UnReducedFraction: new Fraction(4, 8), ExpectedReducedFraction: new Fraction(1, 2));

        private Fraction AnyFractionInLowestTerms() => new Fraction(3, 5);

        private Fraction AnyFractionThatIsZero() => new Fraction(0, 6);

        #endregion
    }
}
