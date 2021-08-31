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

        [Fact]
        public void SumFractionsInitializedOnlyWithNumerator()
        {
            ReducingFractionFactory.CreateFraction(3).Add(ReducingFractionFactory.CreateFraction(4)).Should().Be(ReducingFractionFactory.CreateFraction(7));
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
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 1), ReducingFractionFactory.CreateFraction(3, 1) }, ReducingFractionFactory.CreateFraction(5, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(1, 1), ReducingFractionFactory.CreateFraction(2, 1) }, ReducingFractionFactory.CreateFraction(3, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(0, 1), ReducingFractionFactory.CreateFraction(1, 1) }, ReducingFractionFactory.CreateFraction(1, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(10000, 1), ReducingFractionFactory.CreateFraction(1, 1) }, ReducingFractionFactory.CreateFraction(10001, 1) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {   
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(1, 1), ReducingFractionFactory.CreateFraction(1, 1) }, ReducingFractionFactory.CreateFraction(2, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(1, 2), ReducingFractionFactory.CreateFraction(3, 2) }, ReducingFractionFactory.CreateFraction(4, 2) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(0, 1), ReducingFractionFactory.CreateFraction(1, 1) }, ReducingFractionFactory.CreateFraction(1, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(5, 1), ReducingFractionFactory.CreateFraction(5, 1) }, ReducingFractionFactory.CreateFraction(10, 1) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 3), ReducingFractionFactory.CreateFraction(1, 3) }, ReducingFractionFactory.CreateFraction(3, 3) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(0, 2), ReducingFractionFactory.CreateFraction(2, 3) }, ReducingFractionFactory.CreateFraction(2, 3) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(1, 2), ReducingFractionFactory.CreateFraction(2, 3) }, ReducingFractionFactory.CreateFraction(7, 6) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(3, 4), ReducingFractionFactory.CreateFraction(2, 9) }, ReducingFractionFactory.CreateFraction(35, 36) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(3, 14), ReducingFractionFactory.CreateFraction(8, 21) }, ReducingFractionFactory.CreateFraction(175, 294) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(4, 9), ReducingFractionFactory.CreateFraction(2, 63) }, ReducingFractionFactory.CreateFraction(270, 567) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(15, 22), ReducingFractionFactory.CreateFraction(7, 36) }, ReducingFractionFactory.CreateFraction(694, 792) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 4), ReducingFractionFactory.CreateFraction(4, 4) }, ReducingFractionFactory.CreateFraction(6, 4) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 6), ReducingFractionFactory.CreateFraction(3, 6) }, ReducingFractionFactory.CreateFraction(5, 6) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(4, 8), ReducingFractionFactory.CreateFraction(4, 8) }, ReducingFractionFactory.CreateFraction(8, 8) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(5, 9), ReducingFractionFactory.CreateFraction(1, 9) }, ReducingFractionFactory.CreateFraction(6, 9) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(12, 16), ReducingFractionFactory.CreateFraction(12, 16) }, ReducingFractionFactory.CreateFraction(24, 16) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 4), ReducingFractionFactory.CreateFraction(3, 6) }, ReducingFractionFactory.CreateFraction(24, 24) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(2, 8), ReducingFractionFactory.CreateFraction(3, 6) }, ReducingFractionFactory.CreateFraction(36, 48) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(3, 9), ReducingFractionFactory.CreateFraction(2, 6) }, ReducingFractionFactory.CreateFraction(36, 54) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(10, 10), ReducingFractionFactory.CreateFraction(5, 25) }, ReducingFractionFactory.CreateFraction(300, 250) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(12, 16), ReducingFractionFactory.CreateFraction(22, 18) }, ReducingFractionFactory.CreateFraction(568, 288) },
                new object[] { new Fraction[] { ReducingFractionFactory.CreateFraction(10, 110), ReducingFractionFactory.CreateFraction(100, 10005) }, ReducingFractionFactory.CreateFraction(111050, 1100550) }
            };
        }

        #endregion
    }
}
