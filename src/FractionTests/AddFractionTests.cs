using FluentAssertions;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace FractionTests
{
    public class AddFractionTests
    {
        [Theory]
        [MemberData(nameof(FractionsWithDenominator_1))]
        [MemberData(nameof(FractionsInLowestTermsWithSameDenominator))]
        [MemberData(nameof(FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors))]
        [MemberData(nameof(FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors))]
        [MemberData(nameof(FractionsNotInLowestTermsWithSameDenominator))]
        [MemberData(nameof(FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors))]        
        public void Fractions_Are_Summed_Correctly(int numerator1, int denominator1, int numerator2, int denominator2, int expectedNumerator, 
            int expectedDenominator)
        {
            var fraction1 = new Fraction(numerator1, denominator1);
            var fraction2 = new Fraction(numerator2, denominator2);

            Fraction sumResult = fraction1.Add(fraction2);

            Assert.Equal(sumResult, new Fraction(expectedNumerator, expectedDenominator));
        }

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
        [MemberData(nameof(FractionsInLowestTermsWithSameNumeratorsAndDenominators))]
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

        #region Heplers

        public static IEnumerable<object[]> FractionsWithDenominator_1()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 2, 1, 3, 1, 5, 1 },
                new object[] { 1, 1, 2, 1, 3, 1 },
                new object[] { 0, 1, 1, 1, 1, 1 },
                new object[] { 10000, 1, 1, 1, 10001, 1 }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 1, 1, 1, 1, 2, 1 },
                new object[] { 1, 2, 3, 2, 4, 2 },
                new object[] { 0, 1, 1, 1, 1, 1 },
                new object[] { 5, 1, 5, 1, 10, 1 },
                new object[] { 2, 3, 1, 3, 3, 3 }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 0, 2, 2, 3, 2, 3 },
                new object[] { 1, 2, 2, 3, 7, 6 },
                new object[] { 3, 4, 2, 9, 35, 36 }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithSameNumeratorsAndDenominators()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2
                new object[] { 0, 1, 0, 1 },
                new object[] { 1, 1, 1, 1 },
                new object[] { 1, 2, 1, 2 },
                new object[] { 2, 3, 2, 3 }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 3, 14, 8, 21, 175, 294 },
                new object[] { 4, 9, 2, 63, 270, 567 },
                new object[] { 15, 22, 7, 36, 694, 792 }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 2, 4, 4, 4, 6, 4 },
                new object[] { 2, 6, 3, 6, 5, 6 },
                new object[] { 4, 8, 4, 8, 8, 8 },
                new object[] { 5, 9, 1, 9, 6, 9 },
                new object[] { 12, 16, 12, 16, 24, 16 }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // numerator1, denominator1, numerator2, denominator2, expectedNumerator, expectedDenominator
                new object[] { 2, 4, 3, 6, 24, 24 },
                new object[] { 2, 8, 3, 6, 36, 48 },
                new object[] { 3, 9, 2, 6, 36, 54 },
                new object[] { 10, 10, 5, 25, 300, 250 },
                new object[] { 12, 16, 22, 18, 568, 288 },
                new object[] { 10, 110, 100, 10005, 111050, 1100550 }
            };
        }

        #endregion
    }
}
