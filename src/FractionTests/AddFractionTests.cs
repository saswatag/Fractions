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
            FractionFactory.CreateFraction(3).Add(FractionFactory.CreateFraction(4)).Should().Be(FractionFactory.CreateFraction(7));
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
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 1), FractionFactory.CreateFraction(3, 1) }, FractionFactory.CreateFraction(5, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(1, 1), FractionFactory.CreateFraction(2, 1) }, FractionFactory.CreateFraction(3, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(0, 1), FractionFactory.CreateFraction(1, 1) }, FractionFactory.CreateFraction(1, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(10000, 1), FractionFactory.CreateFraction(1, 1) }, FractionFactory.CreateFraction(10001, 1) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {   
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { FractionFactory.CreateFraction(1, 1), FractionFactory.CreateFraction(1, 1) }, FractionFactory.CreateFraction(2, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(1, 2), FractionFactory.CreateFraction(3, 2) }, FractionFactory.CreateFraction(4, 2) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(0, 1), FractionFactory.CreateFraction(1, 1) }, FractionFactory.CreateFraction(1, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(5, 1), FractionFactory.CreateFraction(5, 1) }, FractionFactory.CreateFraction(10, 1) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 3), FractionFactory.CreateFraction(1, 3) }, FractionFactory.CreateFraction(3, 3) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatDoNotHaveAnyCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { FractionFactory.CreateFraction(0, 2), FractionFactory.CreateFraction(2, 3) }, FractionFactory.CreateFraction(2, 3) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(1, 2), FractionFactory.CreateFraction(2, 3) }, FractionFactory.CreateFraction(7, 6) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(3, 4), FractionFactory.CreateFraction(2, 9) }, FractionFactory.CreateFraction(35, 36) }
            };
        }

        public static IEnumerable<object[]> FractionsInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { FractionFactory.CreateFraction(3, 14), FractionFactory.CreateFraction(8, 21) }, FractionFactory.CreateFraction(175, 294) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(4, 9), FractionFactory.CreateFraction(2, 63) }, FractionFactory.CreateFraction(270, 567) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(15, 22), FractionFactory.CreateFraction(7, 36) }, FractionFactory.CreateFraction(694, 792) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithSameDenominator()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 4), FractionFactory.CreateFraction(4, 4) }, FractionFactory.CreateFraction(6, 4) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 6), FractionFactory.CreateFraction(3, 6) }, FractionFactory.CreateFraction(5, 6) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(4, 8), FractionFactory.CreateFraction(4, 8) }, FractionFactory.CreateFraction(8, 8) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(5, 9), FractionFactory.CreateFraction(1, 9) }, FractionFactory.CreateFraction(6, 9) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(12, 16), FractionFactory.CreateFraction(12, 16) }, FractionFactory.CreateFraction(24, 16) }
            };
        }

        public static IEnumerable<object[]> FractionsNotInLowestTermsWithDifferentDenominatorsThatHaveCommonFactors()
        {
            return new List<object[]>
            {
                // list of fraction operands, expected fraction
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 4), FractionFactory.CreateFraction(3, 6) }, FractionFactory.CreateFraction(24, 24) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(2, 8), FractionFactory.CreateFraction(3, 6) }, FractionFactory.CreateFraction(36, 48) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(3, 9), FractionFactory.CreateFraction(2, 6) }, FractionFactory.CreateFraction(36, 54) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(10, 10), FractionFactory.CreateFraction(5, 25) }, FractionFactory.CreateFraction(300, 250) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(12, 16), FractionFactory.CreateFraction(22, 18) }, FractionFactory.CreateFraction(568, 288) },
                new object[] { new Fraction[] { FractionFactory.CreateFraction(10, 110), FractionFactory.CreateFraction(100, 10005) }, FractionFactory.CreateFraction(111050, 1100550) }
            };
        }

        #endregion
    }
}
