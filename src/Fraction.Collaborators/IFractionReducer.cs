namespace FractionOperations.Collaborators
{
    public interface IFractionReducer
    {
        (int ReducedNumerator, int ReducedDenominator) Reduce(int numerator, int denominator);
    }
}