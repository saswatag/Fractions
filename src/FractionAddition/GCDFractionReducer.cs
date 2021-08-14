using FractionOperation.Utilities;

namespace FractionOperation
{
    public class GCDFractionReducer
    {
        public Fraction Reduce(Fraction fractionOperand)
        {
            int gcdOfNumeratorDenominator = NumberTheory.Gcd(fractionOperand.Numerator, fractionOperand.Denominator);
            return new Fraction(fractionOperand.Numerator/gcdOfNumeratorDenominator, fractionOperand.Denominator/gcdOfNumeratorDenominator);
        }
    }
}