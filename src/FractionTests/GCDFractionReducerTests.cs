using FractionOperation;
using FractionOperations.Collaborators;

namespace FractionTests
{
    public abstract class GCFFractionReducerTests : ReduceFractionContractTests
    {
        protected override IFractionReducer ProvideFractionReducer() => new GCDFractionReducer();
    }
}
