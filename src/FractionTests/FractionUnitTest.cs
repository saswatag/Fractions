using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace FractionTests
{
    public class FractionUnitTest
    {
        [Theory]
        [MemberData(nameof(FractionsWithDenominator_1))]
        [MemberData(nameof(FractionsInLowestFromWithSameDenominator))]
        public void Fractions_With_Same_Denomitor_Are_Summed_Correctly(int numerator1, int denominator1, int numerator2, int denominator2, int expectedNumerator, 
            int expectedDenominator)
        {
            var operand1 = new Fraction(numerator1, denominator1);
            var operand2 = new Fraction(numerator2, denominator2);

            Fraction sumResult = operand1.Add(operand2);

            Assert.True(sumResult.Numerator.Equals(expectedNumerator) && sumResult.Denominator.Equals(expectedDenominator), 
                $"Expected numerator: {expectedNumerator} and denominator: {expectedDenominator}, but got numerator: {sumResult.Numerator} and denominator: {sumResult.Denominator}");
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void Fractions_With_Denomitor_Zero_Are_Not_Allowed(int numerator, int deominator)
        {
            Action createFractionAction = () => new Fraction(numerator, deominator);

            createFractionAction.Should().Throw<ArgumentException>().WithMessage("Fraction with denominator zero is invalid.");
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

        public static IEnumerable<object[]> FractionsInLowestFromWithSameDenominator()
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

        #endregion
    }
}
