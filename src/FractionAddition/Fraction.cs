using System;
using System.Collections.Generic;
using FractionOperation.Utilities;
using FractionOperations.Collaborators;

namespace FractionOperation
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        private readonly IFractionReducer FractionReducer = new GCDFractionReducer();

        public Fraction(int numerator) : this(numerator, 1)
        {
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator.Equals(0))
                throw new ArgumentException("Fraction with denominator zero is invalid.");

            (int ReducedNumerator, int ReducedDenominator) reduced = FractionReducer.Reduce(numerator, denominator);
            Numerator = reduced.ReducedNumerator;
            Denominator = reduced.ReducedDenominator;
        }

        public Fraction Add(Fraction fraction)
        {
            return new Fraction((this.Numerator * fraction.Denominator) + (this.Denominator * fraction.Numerator), this.Denominator * fraction.Denominator);
        }

        public override bool Equals(object obj)
        {
            Fraction otherFraction = obj as Fraction;

            if (obj == null)
                return false;

            return this.Numerator == otherFraction.Numerator && this.Denominator == otherFraction.Denominator;
        }

        public override int GetHashCode()
        {
            return Numerator * 19 + Denominator;
        }

        public override string ToString()
        {
            return $"Fraction with numerator '{Numerator}' and denominator '{Denominator}'";
        }
    }
}