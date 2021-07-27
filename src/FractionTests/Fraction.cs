using System;
using System.Collections.Generic;

namespace FractionTests
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator) : this(numerator, 1)
        {
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator.Equals(0))
                throw new ArgumentException("Fraction with denominator zero is invalid.");

            int gcdOfNumeratorDenominator = NumberTheory.Gcd(numerator, denominator);
            Numerator = numerator / gcdOfNumeratorDenominator;
            Denominator = denominator / gcdOfNumeratorDenominator;
        }

        public Fraction Add(Fraction fraction)
        {
            if (fraction.Denominator == this.Denominator)
                return new Fraction((this.Numerator * fraction.Denominator) + (this.Denominator * fraction.Numerator), this.Denominator * fraction.Denominator);
            else if(this.Numerator == 0)
                return new Fraction(fraction.Numerator, fraction.Denominator);
            else if (fraction.Numerator == 0)
                return new Fraction(this.Numerator, this.Denominator);

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