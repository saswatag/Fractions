using System.Configuration;

namespace FractionTests
{
    internal sealed class NumberTheory
    {
        internal static int Gcd(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
                return firstNumber;
            else
                return Gcd(secondNumber, firstNumber % secondNumber);
        }
    }
}