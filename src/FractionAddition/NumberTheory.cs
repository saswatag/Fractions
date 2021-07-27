using System.Configuration;

namespace FractionOperation.Utilities
{
    public sealed class NumberTheory
    {
        public static int Gcd(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
                return firstNumber;
            else
                return Gcd(secondNumber, firstNumber % secondNumber);
        }
    }
}