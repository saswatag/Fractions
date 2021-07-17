using System;
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
    }
}
