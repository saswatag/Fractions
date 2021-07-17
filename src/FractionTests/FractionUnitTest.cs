using FluentAssertions;
using System;
using System.ComponentModel;
using Xunit;

namespace FractionTests
{
    public class FractionUnitTest
    {
        [Fact]
        public void Fractions_With_Denomitor_1_Are_Summed_correctly()
        {
            var operand1 = new Fraction(2, 1);
            var operand2 = new Fraction(3, 1);

            Fraction sumResult = operand1.Add(operand2);
            
            Assert.True(sumResult.Numerator.Equals(5) && sumResult.Denominator.Equals(1));
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
    }
}
