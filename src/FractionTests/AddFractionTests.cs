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
    public class AddFractionTests
    {
        [Theory]
        [MemberData(nameof(AddFractionsTestData))]
        public void Fractions_Are_Summed_Correctly(Fraction[] fractionsToBeSummed, Fraction expectedFraction)
        {
            fractionsToBeSummed[0].Add(fractionsToBeSummed[1]).Should().Be(expectedFraction);
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

        [Fact]
        public void SumFractionsInitializedOnlyWithNumerator()
        {
            new Fraction(3).Add(new Fraction(4)).Should().Be(new Fraction(7));
        }

        #region Heplers

        public static IEnumerable<object[]> AddFractionsTestData()
        {
            var result = new List<object[]>();
            result.AddRange(FractionsWithDenominator_1());
            result.AddRange(FractionsInLowestTermsWithSameDenominator());
            result.AddRange(FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors());
            result.AddRange(FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors());
            result.AddRange(FractionsNotInLowestTermsWithSameDenominator());
            result.AddRange(FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors());

            return result.ToArray();
        }

        public static IEnumerable<object[]> FractionsWithDenominator_1()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(2, 1), new Fraction(3, 1) }, new Fraction(5, 1) },
                new object[] { new Fraction[] { new Fraction(1, 1), new Fraction(2, 1) }, new Fraction(3, 1) },
                new object[] { new Fraction[] { new Fraction(0, 1), new Fraction(1, 1) }, new Fraction(1, 1) },
                new object[] { new Fraction[] { new Fraction(10000, 1), new Fraction(1, 1) }, new Fraction(10001, 1) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {   
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(1, 1), new Fraction(1, 1) }, new Fraction(2, 1) },
                new object[] { new Fraction[] { new Fraction(1, 2), new Fraction(3, 2) }, new Fraction(4, 2) },
                new object[] { new Fraction[] { new Fraction(0, 1), new Fraction(1, 1) }, new Fraction(1, 1) },
                new object[] { new Fraction[] { new Fraction(5, 1), new Fraction(5, 1) }, new Fraction(10, 1) },
                new object[] { new Fraction[] { new Fraction(2, 3), new Fraction(1, 3) }, new Fraction(3, 3) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(0, 2), new Fraction(2, 3) }, new Fraction(2, 3) },
                new object[] { new Fraction[] { new Fraction(1, 2), new Fraction(2, 3) }, new Fraction(7, 6) },
                new object[] { new Fraction[] { new Fraction(3, 4), new Fraction(2, 9) }, new Fraction(35, 36) }
            };
        }

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

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(3, 14), new Fraction(8, 21) }, new Fraction(175, 294) },
                new object[] { new Fraction[] { new Fraction(4, 9), new Fraction(2, 63) }, new Fraction(270, 567) },
                new object[] { new Fraction[] { new Fraction(15, 22), new Fraction(7, 36) }, new Fraction(694, 792) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(2, 4), new Fraction(4, 4) }, new Fraction(6, 4) },
                new object[] { new Fraction[] { new Fraction(2, 6), new Fraction(3, 6) }, new Fraction(5, 6) },
                new object[] { new Fraction[] { new Fraction(4, 8), new Fraction(4, 8) }, new Fraction(8, 8) },
                new object[] { new Fraction[] { new Fraction(5, 9), new Fraction(1, 9) }, new Fraction(6, 9) },
                new object[] { new Fraction[] { new Fraction(12, 16), new Fraction(12, 16) }, new Fraction(24, 16) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { new Fraction(2, 4), new Fraction(3, 6) }, new Fraction(24, 24) },
                new object[] { new Fraction[] { new Fraction(2, 8), new Fraction(3, 6) }, new Fraction(36, 48) },
                new object[] { new Fraction[] { new Fraction(3, 9), new Fraction(2, 6) }, new Fraction(36, 54) },
                new object[] { new Fraction[] { new Fraction(10, 10), new Fraction(5, 25) }, new Fraction(300, 250) },
                new object[] { new Fraction[] { new Fraction(12, 16), new Fraction(22, 18) }, new Fraction(568, 288) },
                new object[] { new Fraction[] { new Fraction(10, 110), new Fraction(100, 10005) }, new Fraction(111050, 1100550) }
            };
        }

        #endregion
    }
}
