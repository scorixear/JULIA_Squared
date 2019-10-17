using System;
using System.Collections.Generic;
using System.Numerics;

namespace JULIA_Squared
{
    public static class Julia
    {
        public static List<List<BigInteger>> CalculateSimpleMandelbrot()
        {
            return CalculateMandelbrot((-2, 2), (2, -2), 1000, 1000, 2, 1000);
        }
        public static List<List<BigInteger>> CalculateMandelbrot(ComplexNumber topLeft, ComplexNumber bottomRight,
            BigInteger resolutionWidth,
            BigInteger resolutionHeight, Rational escapeDelimiter)
        {
            return CalculateMandelbrot(topLeft, bottomRight, resolutionWidth, resolutionHeight, escapeDelimiter, 1000);
        }
        public static List<List<BigInteger>> CalculateMandelbrot(ComplexNumber topLeft, ComplexNumber bottomRight, BigInteger resolutionWidth,
            BigInteger resolutionHeight, Rational escapeDelimiter, BigInteger maxCalculations)
        {
            return Calculate(topLeft, bottomRight, resolutionWidth, resolutionHeight, (z, c) => z * z + c,0, escapeDelimiter, maxCalculations);
        }

        public static List<List<BigInteger>> Calculate(ComplexNumber topLeft, ComplexNumber bottomRight, BigInteger resolutionWidth, BigInteger resolutionHeight, Func<ComplexNumber, ComplexNumber, ComplexNumber> juliaFunction, ComplexNumber start, Rational escapeDelimiter)
        {
            return Calculate(topLeft, bottomRight, resolutionWidth, resolutionHeight, juliaFunction, start, escapeDelimiter, 1000);
        }

        public static List<List<BigInteger>> Calculate(ComplexNumber topLeft, ComplexNumber bottomRight, BigInteger resolutionWidth, BigInteger resolutionHeight, Func<ComplexNumber, ComplexNumber, ComplexNumber> juliaFunction, ComplexNumber start, Rational escapeDelimiter, BigInteger maxCalculations)
        {
            List<List<BigInteger>> returnCalculations = new List<List<BigInteger>>();
            Rational stepWidth = (bottomRight.RealPart - topLeft.RealPart) / resolutionWidth;
            Rational stepHeight = (topLeft.ComplexPart - bottomRight.ComplexPart) / resolutionHeight;
            for (BigInteger x = 0; x < resolutionWidth; x++)
            {
                List<BigInteger> widthList = new List<BigInteger>();
                Rational complex = topLeft.ComplexPart - x * stepHeight;
                for (BigInteger y = 0; y < resolutionHeight; y++)
                {
                    ComplexNumber value = (topLeft.RealPart + y*stepWidth,complex);

                    widthList.Add(CalculateJulia(value, start,maxCalculations, juliaFunction, escapeDelimiter));

                }
                returnCalculations.Add(widthList);
            }

            return returnCalculations;
        }

        public static BigInteger CalculateJulia(ComplexNumber value, ComplexNumber start, BigInteger maxCalculations, Func<ComplexNumber,ComplexNumber, ComplexNumber> juliaFunction, Rational escapeDelimiter)
        {
            ComplexNumber begin = (ComplexNumber)start.Clone();
            for (BigInteger i = 0; i < maxCalculations; i++)
            {
                begin = juliaFunction.Invoke(begin,value);
                if (begin.Distance(new ComplexNumber()) >= escapeDelimiter )
                {
                    return i;
                }
            }

            return BigInteger.Zero;
        }
    }
}
