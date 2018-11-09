using System;
using System.Numerics;

namespace Gauss
{
    internal class FractionType : ICloneable
    {
        private readonly BigInteger _numerator = 0;
        private readonly BigInteger _denominator = 1;

        public object Clone() => new FractionType(_numerator, _denominator);

        private BigInteger _greatestCommonDenominator(BigInteger x, BigInteger y)
        {
            x = BigInteger.Abs(x);
            y = BigInteger.Abs(y);
            return y == 0 ? x : _greatestCommonDenominator(y, x % y);
        }

        public FractionType(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();

            if (numerator == 0)
            {
                _numerator = 0;
                _denominator = 1;
            }
            else
            {
                var gcd = _greatestCommonDenominator(numerator, denominator);
                _numerator = numerator / gcd;
                _denominator = denominator / gcd;
            }
        }

        public static explicit operator int(FractionType fractionType) => (int) fractionType._numerator / (int) fractionType._denominator;
        public static explicit operator float(FractionType fractionType) => (float) fractionType._numerator / (float) fractionType._denominator;
        public static explicit operator double(FractionType fractionType) => (double) fractionType._numerator / (double) fractionType._denominator;
    }
}
