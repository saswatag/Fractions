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
        public void GCDIsCommutative()
        {
            (int NumberOne, int NumnerTwo, int ExpectedGCD) anyPairWithCommonFactors = (NumberOne: 12, NumnerTwo: 42, ExpectedGCD: 6);

            NumberTheory.Gcd(anyPairWithCommonFactors.NumberOne, anyPairWithCommonFactors.NumnerTwo).Should().Be(anyPairWithCommonFactors.ExpectedGCD);
            NumberTheory.Gcd(anyPairWithCommonFactors.NumnerTwo, anyPairWithCommonFactors.NumberOne).Should().Be(anyPairWithCommonFactors.ExpectedGCD);
        }

        [Fact]
        public void GCDOfTwoUnEqualPrimeNumbersIsTheSmallerNumber()
        {
            NumberTheory.Gcd(7, 19).Should().Be(1);
            NumberTheory.Gcd(3, 5).Should().Be(1);
        }

        [Fact]
        public void GCDOfTwoNonZeroEqualNumbersIsTheSameNumber()
        {
            int anyNonZeroNumber = 4;
            NumberTheory.Gcd(anyNonZeroNumber, anyNonZeroNumber).Should().Be(anyNonZeroNumber);
        }

        [Fact]
        public void GCDOfTwoNonZeroNumbersWithCommonFactors()
        {
            (int NumberOne, int NumnerTwo, int ExpectedGCD) anyPairWithCommonFactors = (NumberOne: 6, NumnerTwo: 15, ExpectedGCD: 3);
            NumberTheory.Gcd(anyPairWithCommonFactors.NumberOne, anyPairWithCommonFactors.NumnerTwo).Should().Be(anyPairWithCommonFactors.ExpectedGCD);
        }
    }
}
