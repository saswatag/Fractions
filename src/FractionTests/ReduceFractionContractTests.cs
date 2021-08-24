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
            (int UnReducedNumerator, int UnReducedDenominator, int ReducedNumerator, int ReducedDenominator) testData
                = AnyUnReducedNumeratorDenominatorAndTheCorrespondingReducedForm();
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(testData.UnReducedNumerator, testData.UnReducedDenominator);

            reduced.ReducedNumerator.Should().Be(testData.ReducedNumerator);
            reduced.ReducedDenominator.Should().Be(testData.ReducedDenominator);
        }

        [Fact]
        public void ReduceFractionAreadyInLowestTerms()
        {
            (int ReducedNumerator, int ReducedDenominator) testData = AnyNumeratorDenominatorPairInLowestTerms();
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(testData.ReducedNumerator, testData.ReducedDenominator);

            reduced.ReducedNumerator.Should().Be(testData.ReducedNumerator);
            reduced.ReducedDenominator.Should().Be(testData.ReducedDenominator);
        }

        [Fact]
        public void ReduceFractionThatIsZero()
        {
            (int Numerator, int Denominator) zeroFraction = AnyFractionThatIsZero();
            IFractionReducer fractionReducer = ProvideFractionReducer();

            (int ReducedNumerator, int ReducedDenominator) reduced = fractionReducer.Reduce(zeroFraction.Numerator, zeroFraction.Denominator);
            
            reduced.ReducedNumerator.Should().Be(zeroFraction.Numerator);
            reduced.ReducedDenominator.Should().Be(zeroFraction.Denominator);
        }

        #region Helpers

        private (int UnReducedNumerator, int UnReducedDenominator, int ReducedNumerator, int ReducedDenominator) AnyUnReducedNumeratorDenominatorAndTheCorrespondingReducedForm() =>
            (UnReducedNumerator: 4, UnReducedDenominator: 8, ReducedNumerator: 1, ReducedDenominator: 2);

        private (int Numerator, int Denominator) AnyNumeratorDenominatorPairInLowestTerms() => (Numerator: 3, Denominator: 5);
        
        private (int Numerator, int Denominator) AnyFractionThatIsZero() => (Numerator: 0, Denominator: 6);

        #endregion
    }
}
