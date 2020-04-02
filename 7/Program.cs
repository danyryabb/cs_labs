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

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number");
            var num1 = EnterNumber();
            Console.Write("Enter the second number");
            var num2 = EnterNumber();
            Console.Clear();

            //RationalNumber num1 = new RationalNumber(1, 2);
            //RationalNumber num2 = new RationalNumber(2, 3);

            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");


            Console.WriteLine($"{num1} < {num2} - {num1 < num2}");
            Console.WriteLine($"{num1} > {num2} - {num1 > num2}");
            Console.WriteLine($"{num1} == {num2} - {num1 == num2}");
            Console.WriteLine($"{num1} != {num2} - {num1 != num2}");
            Console.WriteLine($"{num1} >= {num2} - {num1 >= num2}");
            Console.WriteLine($"{num1} <= {num2} - {num1 <= num2}");


        }
        public static int CheckDenumenator()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.Write("Wrong input, repeat: ");
            return a;
        }

        public static int CheckNumenator()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
                Console.Write("Wrong input, repeat: ");
            return a;
        }
        public static double CheckDouble()
        {
            double a;
            while (!double.TryParse(Console.ReadLine(), out a))
                Console.Write("Wrong input, repeat: ");
            return a;
        }
        public static bool CheckRational(string numinstr)
        {
            for (int i = 0; i < numinstr.Length; i++)
            {
                if (i == 0 && numinstr[i] == '-') i++;
                if (numinstr[i] == '/' && i != numinstr.Length - 1) i++;
                if (!char.IsDigit(numinstr[i]) || (numinstr[i] == '0' && i == numinstr.Length - 1 && numinstr[i - 1] == '/')) return false;
            }
            return true;
        }


        public static RationalNumber EnterNumber()
        {
            int num;
            Console.Write(" (0 - Rat, 1 - Number): ");
            while (!int.TryParse(Console.ReadLine(), out num) || num < 0 || num > 1)
                Console.Write("Wrong input, repeat: ");
            if (num == 0) return GetRational();
            else return GetNumber();
        }


        public static RationalNumber GetNumber()
        {
            Console.Write("Number: ");
            double number = CheckDouble();
            return new RationalNumber(number);
        }
        public static RationalNumber GetRational()
        {
            Console.Write("Num: ");
            string str = Console.ReadLine();
            while (!CheckRational(str))
            {
                Console.Write("Wrong input, repeat: ");
                str = Console.ReadLine();
            }
            try
            {
                string[] arr = str.Split('/');
                return new RationalNumber(int.Parse(arr[0]), int.Parse(arr[1]));
            }
            catch
            {
                return new RationalNumber(int.Parse(str), 1);
            }
        }
    }
}
