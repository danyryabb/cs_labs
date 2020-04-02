using System;

namespace ClassCreating
{
    class Program
    {
        static void Main(string[] args)
        {
            Human obja = new Human("Stasuk", "Marian", "Luban", "Gumnasium N1", 2001);
            Console.WriteLine(obja);
            
            Console.WriteLine("Enter qunantity of humans: ");
            int amount = CheckInt();
            Human[] hum = new Human[amount];
            for (int i = 0; i < hum.Length; i++)
            {
                hum[i] = new Human();
                hum[i].Filling(i);
            }
            Choose(ref hum);
            Console.ReadKey();
        }
        static void Choose(ref Human[] hum)
        {
            do
            {
                Console.WriteLine("Enter number of object");
                int num = CheckInt();
                if (num <= hum.Length && hum.Length > 0)
                {
                    do
                    {
                        int value = menu();
                        if (value == 1)
                        {
                            hum[num].delByIndex(ref hum, num);
                            break;
                        }
                        else if (value == 2) Console.WriteLine(hum[--num]);
                        else if (value == 3) hum[--num].GetInfo(--num);
                        else Console.WriteLine("Wrong input");

                    } while (value > 0);
                }
                else Console.WriteLine("Wrong input");
            } while (num > 0);
            
        }
        static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.Write("Incorrect data, repeat: ");
            return a;
        }
        static int menu()
        {
            Console.WriteLine("Choose what u want to do: ");
            Console.WriteLine("1. Delete object");
            Console.WriteLine("2. Get info");
            Console.WriteLine("3. Check object");
            int val = CheckInt();
            return val;
        }
    }
}
