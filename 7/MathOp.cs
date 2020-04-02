
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp
{
    public class RationalNumber : IEquatable<RationalNumber>, IComparable
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        double rational;

        public RationalNumber()
        {
            Numerator = 1;
            Denominator = 1;
        }
        public RationalNumber(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = (Denominator > 0) ? Denominator : 1;
            rational = (double)Numerator / Denominator;
        }

        public RationalNumber(double num)
        {
            rational = num;
            int count = -1;
            if (num % 10 == 0)
            {
                Numerator = (int)num;
                Denominator = 1;
                rational = num;
            }
            else
            {
                for (int i = 0; (float)num % 10 != 0 || Math.Abs(num) < 1; i++)
                {
                    num *= 10;
                    count++;
                }
                num /= 10;
                Numerator = (int)num;
                Denominator = (int)Math.Pow(10, count);
            }
        }
        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber
                (
                    (int)(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator),
                    r1.Denominator * r2.Denominator
                );
        }
        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber
                (
                    (int)(r1.Numerator * r2.Numerator),
                     (int)(r1.Denominator * r2.Denominator)
                );
        }
        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber
                (
                    (int)(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator),
                    r1.Denominator * r2.Denominator
                );
        }
        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = num1.Numerator * num2.Denominator;
            num.Denominator = num1.Denominator * num2.Numerator;
            num.rational = num1.rational / num2.rational;
            return num;
        }
        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return (r1 - r2).rational > 0;
        }
        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return (r1 - r2).rational < 0;
        }
        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return r1.rational == r2.rational;
        }
        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 > r2);
        }
        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 < r2);
        }
        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1.rational == r2.rational);
        }
        int IComparable.CompareTo(object obj)
        {
            if (this.rational > ((RationalNumber)obj).rational) return 1;
            if (this.rational < ((RationalNumber)obj).rational) return -1;
            else return 0;
        }
        public override bool Equals(object obj) => base.Equals(obj);
        public static implicit operator int(RationalNumber num) => (int)num.rational;
        public static implicit operator double(RationalNumber num) => num.rational;
        public override int GetHashCode() => rational.GetHashCode();
        bool IEquatable<RationalNumber>.Equals(RationalNumber num) => this.rational == num.rational;

        public override string ToString() => $"{Numerator}/{Denominator}";

    }
}    
