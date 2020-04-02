using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number");
            var num1 = EnterNumber();
            Console.Write("Enter the second number");
            var num2 = EnterNumber();
            Console.Clear();

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
