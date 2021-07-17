using System;
using System.Collections.Generic;

namespace FractionTests
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public Fraction(int numerator, int denominator)
        {
            if (denominator.Equals(0))
                throw new ArgumentException("Fraction with denominator zero is invalid.");

            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Add(Fraction fraction)
        {
            return new Fraction(this.Numerator + fraction.Numerator, this.Denominator);
        }
    }
}