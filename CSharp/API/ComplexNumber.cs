using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnu.MP;

namespace ZETA_Squared
{
    class ComplexNumber : IComparable<ComplexNumber>, IComparable, ICloneable
    {

        public Real RealPart { get; private set; }
        public Real ComplexPart { get; private set; }

        public ComplexNumber(Real real = null, Real complex = null)
        {
            RealPart = real ?? new Real(0);
            ComplexPart = complex ?? new Real(0);
        }

        public ComplexNumber(double real = 0, double complex = 0.0) : this(new Real(real), new Real(complex)) { }

        public ComplexNumber(int real = 0, int complex = 0) : this(new Real(real), new Real(complex)) { }

        public ComplexNumber(uint real = 0, uint complex = 0) : this(new Real(real), new Real(complex)) { }

        public static implicit operator ComplexNumber(Real r)
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
            if (obj is Real rObj)
                return rObj.CompareTo(RealPart);
            if (obj is Gnu.MP.Rational grObj)
                return grObj.CompareTo(RealPart);
            throw new NotSupportedException("This type of comparison is not supported!");
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
