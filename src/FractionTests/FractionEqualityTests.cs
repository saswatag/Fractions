using FluentAssertions;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;
using FractionOperation;
using System.Linq;

namespace FractionTests
{
    public class FractionEqualityTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void Fractions_With_Denominator_Zero_Are_Not_Allowed(int numerator, int deominator)
        {
            Action createFractionAction = () => new Fraction(numerator, deominator);

            createFractionAction.Should().Throw<ArgumentException>().WithMessage("Fraction with denominator zero is invalid.");
        }

        [Theory]
        [MemberData(nameof(FractionsWithSameNumeratorsAndDenominators))]
        public void Fractions_With_Same_Numerators_And_Denominators_Are_Equal(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            var fraction1 = new Fraction(numerator1, denominator1);
            var fraction2 = new Fraction(numerator2, denominator2);

            Assert.Equal(fraction1, fraction2);
        }

        [Fact]
        public void No_Fraction_IsEqualTo_Null()
        {
            int anyIntegerValueForNumerator = 1;
            int anyNonZeroIntegerValueForDenominator = 2;

            var fraction = new Fraction(anyIntegerValueForNumerator, anyNonZeroIntegerValueForDenominator);            

            Assert.NotEqual(null, fraction);
        }

        [Fact]
        public void FractionsWithDenominatorOneAreInitializedOnlyWithNumerator()
        {
            var fraction = new Fraction(3);
            fraction.Denominator.Should().Be(1);
        }

        #region Heplers

        public static IEnumerable<object[]> FractionsWithSameNumeratorsAndDenominators()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 0, 1, 0, 1 },
                new object[] { 1, 1, 1, 1 },
                new object[] { 1, 2, 1, 2 },
                new object[] { 2, 3, 2, 3 }
            };
        }

        #endregion
    }
}
