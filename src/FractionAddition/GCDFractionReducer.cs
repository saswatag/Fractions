using FractionOperation.Utilities;

namespace FractionOperation
{
    public class GCDFractionReducer
    {
        public (int ReducedNumerator, int ReducedDenominator) Reduce(int numerator, int denominator)
        {
            int gcdOfNumeratorDenominator = NumberTheory.Gcd(numerator, denominator);
            return (ReducedNumerator: numerator / gcdOfNumeratorDenominator, ReducedDenominator: denominator / gcdOfNumeratorDenominator);
        }
    }
}