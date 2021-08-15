using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;
using FractionOperation;
using System.Reflection.Metadata.Ecma335;

namespace FractionTests
{
    public abstract class GCFFractionReducerTests : ReduceFractionContractTests
    {
        protected override IFractionReducer ProvideFractionReducer() => new GCDFractionReducer();
    }
}
