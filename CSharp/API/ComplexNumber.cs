using System;

namespace ZETA_Squared
{
    class ComplexNumber : IComparable<ComplexNumber>, IComparable, ICloneable
    {

        public Rational RealPart { get; private set; }
        public Rational ComplexPart { get; private set; }

        public ComplexNumber(Rational real = null, Rational complex = null)
        {
            RealPart = real ?? new Rational(0);
            ComplexPart = complex ?? new Rational(0);
        }

        public ComplexNumber(double real = 0, double complex = 0.0) : this(new Rational(real), new Rational(complex)) { }

        public ComplexNumber(int real = 0, int complex = 0) : this(new Rational(real), new Rational(complex)) { }

        public ComplexNumber(uint real = 0, uint complex = 0) : this(new Rational(real), new Rational(complex)) { }

        public static implicit operator ComplexNumber(Rational r)
        {
            return new ComplexNumber(r);
        }

        public static implicit operator ComplexNumber(double d)
        {
            return new ComplexNumber(d);
        }

        public static implicit operator ComplexNumber(int i)
        {
            return new ComplexNumber(i);
        }

        public static implicit operator ComplexNumber(uint i)
        {
            return new ComplexNumber(i);
        }

        public static implicit operator ComplexNumber((Rational r, Rational c) p)
        {
            return new ComplexNumber(p.r, p.c);
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart + b.RealPart, a.ComplexPart + b.ComplexPart);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart - b.RealPart, a.ComplexPart - b.ComplexPart);
        }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return  new ComplexNumber(a.RealPart * b.RealPart - a.ComplexPart*b.ComplexPart, a.RealPart * b.ComplexPart + a.ComplexPart * b.RealPart);
        }
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            Rational denominator = b.RealPart * b.RealPart + b.ComplexPart *b.ComplexPart;
            if (denominator == 0)
            {
                throw new ArgumentNullException(nameof(b), "Denominator is effectively zero.");
            }
            ComplexNumber numerator = a * b.Negate();
            return new ComplexNumber(a.RealPart/denominator, b.RealPart/denominator);
        }

        public ComplexNumber Negate()
        {
            return new ComplexNumber((Rational)RealPart.Clone(), -1*ComplexPart);
        }



        public int CompareTo(ComplexNumber other)
        {
            return other.RealPart == this.RealPart ? other.ComplexPart.CompareTo(this.ComplexPart) : other.RealPart.CompareTo(this.RealPart);
        }

        public int CompareTo(object obj)
        {
            if (obj is double dObj)
                return dObj.CompareTo(RealPart);
            if (obj is int iObj)
                return iObj.CompareTo(RealPart);
            if (obj is uint uiObj)
                return uiObj.CompareTo(RealPart);
            if (obj is Rational rObj)
                return rObj.CompareTo(RealPart);
            throw new NotSupportedException("This type of comparison is not supported!");
        }

        public object Clone()
        {
            return ((Rational)RealPart.Clone(), (Rational)ComplexPart.Clone());
        }
    }
}
