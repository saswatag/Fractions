using FractionOperation.Utilities;
using FractionOperations.Collaborators;

namespace FractionOperation
{
    public class GCDFractionReducer : IFractionReducer
    {
        public (int ReducedNumerator, int ReducedDenominator) Reduce(int numerator, int denominator)
        {
            int gcdOfNumeratorDenominator = NumberTheory.Gcd(numerator, denominator);
            return (ReducedNumerator: numerator / gcdOfNumeratorDenominator, ReducedDenominator: denominator / gcdOfNumeratorDenominator);
        }
    }
}