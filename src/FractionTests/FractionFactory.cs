using FractionOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionTests
{
    internal static class FractionFactory
    {
        internal static Fraction CreateFraction(int numerator)
        {
            return CreateFraction(numerator, 1);
        }

        internal static Fraction CreateFraction(int numerator, int denominator)
        {
            return new Fraction(numerator, denominator);
        }
    }
}
