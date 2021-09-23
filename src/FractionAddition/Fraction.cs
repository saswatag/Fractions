using System;
using System.Collections.Generic;
using FractionOperations.Collaborators;

namespace FractionOperation
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        private readonly IFractionReducer _fractionReducer;

        public Fraction(int numerator, IFractionReducer fractionReducer) : this(numerator, 1, fractionReducer)
        {            
        }

        public Fraction(int numerator, int denominator, IFractionReducer fractionReducer)
        {
            if (denominator.Equals(0))
                throw new ArgumentException("Fraction with denominator zero is invalid.");

            _fractionReducer = fractionReducer;

            (int ReducedNumerator, int ReducedDenominator) reduced = _fractionReducer.Reduce(numerator, denominator);
            Numerator = reduced.ReducedNumerator;
            Denominator = reduced.ReducedDenominator;
        }

        public Fraction Add(Fraction fraction)
        {
            return new Fraction((this.Numerator * fraction.Denominator) + (this.Denominator * fraction.Numerator), this.Denominator * fraction.Denominator, _fractionReducer);
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