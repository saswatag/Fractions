namespace FractionOperation
{
    public interface IFractionReducer
    {
        (int ReducedNumerator, int ReducedDenominator) Reduce(int numerator, int denominator);
    }
}