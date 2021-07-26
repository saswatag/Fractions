using FluentAssertions;
using Xunit;

namespace FractionTests
{
    public class GCDTests
    {
        [Fact]
        public void GCDOfTwoZerosIsZero()
        {
            NumberTheory.Gcd(0, 0).Should().Be(0);
        }

        [Fact]
        public void GCDOfOneAndAnyNumberIsOne()
        {
            NumberTheory.Gcd(1, 30).Should().Be(1);
        }

        [Fact]
        public void GCDOfTwoUnEqualPrimeNumbersIsTheSmallerNumber()
        {
            NumberTheory.Gcd(7, 19).Should().Be(7);
            NumberTheory.Gcd(3, 5).Should().Be(3);
        }

        [Fact]
        public void GCDOfTwoNonZeroEqualNumbersIsTheSameNumber()
        {
            int anyNonZeroNumber = 4;
            NumberTheory.Gcd(anyNonZeroNumber, anyNonZeroNumber).Should().Be(anyNonZeroNumber);
        }
    }
}
