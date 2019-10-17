using System;
using System.Numerics;

namespace JULIA_Squared
{
    public class Rational : IComparable<Rational>, IComparable, ICloneable, IEquatable<Rational>
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }
        public Rational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentNullException(nameof(denominator));
            }
            Init(numerator, denominator);
        }

        public Rational(BigInteger numerator) : this(numerator, 1) { }

        public Rational(double d) : this(d, BigInteger.Parse("131072")) { }
        public Rational(double d, BigInteger maximumDenominator)
        {

            /* Translated from the C version. */
            /*  a: continued fraction coefficients. */
            var h = new BigInteger[3] { 0, 1, 0 };
            var k = new BigInteger[3] { 1, 0, 0 };
            BigInteger y = BigInteger.Zero, n = BigInteger.One;
            int i, neg = 0;

            if (maximumDenominator <= 1)
            {
                Init(new BigInteger(d), 1);
                return;
            }

            if (y < 0) { neg = 1; d = -d; }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (d != Math.Floor(d)) { n <<= 1; d *= 2; }
            y = new BigInteger(d);

            /* continued fraction and check denominator each step */
            for (i = 0; i < 64; i++)
            {
                var a = (n != 0) ? y / n : 0;
                if ((i != 0) && (a == 0)) break;

                var x = y; y = n; n = x % n;

                x = a;
                if (k[1] * a + k[0] >= maximumDenominator)
                {
                    x = (maximumDenominator - k[0]) / k[1];
                    if (x * 2 >= a || k[1] >= maximumDenominator)
                        i = 65;
                    else
                        break;
                }

                h[2] = x * h[1] + h[0]; h[0] = h[1]; h[1] = h[2];
                k[2] = x * k[1] + k[0]; k[0] = k[1]; k[1] = k[2];
            }
            Init(neg != 0 ? -h[1] : h[1], k[1]);
        }

        public Rational(int i = 0) : this(numerator: i, 1) { }

        public Rational(uint ui) : this(numerator: ui, 1) { }


        public static implicit operator Rational(double d)
        {
            return new Rational(d);
        }

        public static implicit operator Rational(int i)
        {
            return new Rational(i);
        }

        public static implicit operator Rational(uint i)
        {
            return new Rational(i);
        }

        public static implicit operator Rational(BigInteger bI)
        {
            return new Rational(bI);
        }

        public static implicit operator Rational((BigInteger n, BigInteger d) p)
        {
            return new Rational(p.n, p.d);
        }

        public static explicit operator decimal(Rational r)
        {
            return ((decimal) r.Numerator) / ((decimal) r.Denominator);
        }

        public static explicit operator double(Rational r)
        {
            return ((double)r.Numerator) / ((double)r.Denominator);
        }

        public static bool operator <=(Rational a, Rational b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            return a.CompareTo(b) >= 0;
        }


        public static bool operator <(Rational a, Rational b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a.CompareTo(b) > 0;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            BigInteger gcd = GCD(a.Denominator, b.Denominator);
            BigInteger aN = a.Numerator * (gcd / a.Denominator);
            BigInteger bN = b.Numerator * (gcd / b.Denominator);
            return new Rational(aN+bN, gcd);
        }
        public static Rational operator -(Rational a, Rational b)
        {
            BigInteger gcd = GCD(a.Denominator, b.Denominator);
            BigInteger aN = a.Numerator * (gcd / a.Denominator);
            BigInteger bN = b.Numerator * (gcd / b.Denominator);
            return new Rational(aN - bN, gcd);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.Numerator*b.Numerator, a.Denominator*b.Denominator);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.Numerator*b.Denominator, a.Denominator*b.Numerator);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return a.Equals(b) == false;
        }


        public int CompareTo(Rational other)
        {
            if (other.Denominator == this.Denominator) return 0;
            BigInteger lcm = LCM(Denominator, other.Denominator);
            BigInteger dN = other.Numerator * (lcm/other.Denominator);
            BigInteger tN = Numerator * (lcm / Denominator);
            return dN.CompareTo(tN);

        }

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case double dObj:
                    return CompareTo(new Rational(dObj));
                case int iObj:
                    return CompareTo(new Rational(iObj));
                case uint uiObj:
                    return CompareTo(new Rational(uiObj));
                case Rational rObj:
                    return CompareTo(rObj);
                default:
                    throw new ArgumentException("This type is not supported for comparison.");
            }
        }

        public object Clone()
        {
            return new Rational(Numerator, Denominator);
        }

        public bool Equals(Rational other)
        {
            if (other == null)
                return false;
            return this.Denominator == other.Denominator && this.Numerator == other.Numerator;
        }

        private void Init(BigInteger numerator, BigInteger denominator)
        {
            if (denominator < 0)
            {
                denominator *= -1;
                numerator *= -1;
            }

            BigInteger gcd = GCD(numerator, denominator);
            while (gcd > 1 )
            {
                numerator /= gcd;
                denominator /= gcd;
                gcd = GCD(numerator, denominator);
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        // ReSharper disable once InconsistentNaming
        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        // ReSharper disable once InconsistentNaming
        private static BigInteger LCM(BigInteger a, BigInteger b)
        {
            BigInteger num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }

        public BigInteger Floor()
        {
            BigInteger i = 0;
            BigInteger numerator = Numerator;
            BigInteger denominator = Denominator;
            if (numerator >= 0)
            {
                while (numerator > denominator)
                {
                    i++;
                    numerator = numerator - denominator;
                }
            }
            else
            {
                while (numerator < denominator)
                {
                    i--;
                    numerator = numerator + denominator;
                }
            }
            return i;
        }

        private Rational ToPositive()
        {
            if (Numerator < 0)
            {
                return new Rational(Numerator*-1, Denominator);
            }

            return new Rational(Numerator, Denominator);
        }

        public static Rational ApproximateSqrt(Rational rational, Rational threshHold)
        {
            Rational start = (Rational)rational.Clone();
            Rational solution = Math.Sqrt((double) rational);
            while((solution - start).ToPositive() < threshHold )
            {
                solution = (solution + start / solution) / 2;
            }

            return solution;
        }
    }
}
