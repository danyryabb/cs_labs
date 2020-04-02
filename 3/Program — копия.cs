using System;

namespace ClassCreating
{
    public class Human
    {
        public String SecondName { get; set; }
        public String FirstName { get; set; }
        public String PlaceOfBirth { get; set; }
        public String SchoolName { get; set; }
        public int YearOfBirth { get; set; }
        private static int counter { get; set; }

        public Human()
        {
            SecondName = SecondName;
            FirstName = FirstName;
            YearOfBirth = YearOfBirth;
            PlaceOfBirth = PlaceOfBirth;
            SchoolName = SchoolName;
            counter++;
        }
        ~Human()
        {
            SecondName = null;
            FirstName = null;
            YearOfBirth = 0;
            PlaceOfBirth = null;
            SchoolName = null;
            counter = 0;
        }
        public void DisplayId()
        {
            Console.WriteLine($"Уникальный {counter} объекта Human");
        }
        public void GetInfo()
        {
            Console.WriteLine($"Second Name: {SecondName}\tFirst name: {FirstName}\tPlace of birth: {PlaceOfBirth}\t" +
                $"School name is: {SchoolName}\tYear of birth: {YearOfBirth}");
        }
        public void GetInfo(int index)
        {
            if (2020 - YearOfBirth < 17) Console.WriteLine($"Person number {++index} is studying at {SchoolName} school");
            else if (2020 - YearOfBirth < 6) Console.WriteLine($"Person number {++index} is not studying at school");
            else Console.WriteLine($"Person number {++index} graduated {SchoolName} school  {2020 - YearOfBirth - 17} year(years) ago");
        }

        public void Filling(int index)
        {
            Console.WriteLine($"Enter {++index} human`s 2nd name: ");
            SecondName = Console.ReadLine();
            Console.WriteLine($"Enter {index} human`s 1st name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine($"Enter {index} human`s place of birth: ");
            PlaceOfBirth = Console.ReadLine();
            Console.WriteLine($"Enter {index} human`s school name: ");
            SchoolName = Console.ReadLine();
            Console.WriteLine($"Enter {index} human`s year of birth: ");
            do
            {
                YearOfBirth = int.Parse(Console.ReadLine());
            } while (YearOfBirth > 1940);

        }
        public void delByIndex(ref Human[] data, int delIndex, ref int counter)
        {
            counter--;
            delIndex--;
            Human[] obj = new Human[counter];
            for (int i = 0; i < delIndex; i++)
            {
                obj[i] = new Human();
                obj[i] = data[i];
            }
            for (int i = delIndex; i < counter; i++)
            {
                obj[i] = new Human();
                obj[i] = data[i + 1];
            }
            data = obj;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter qunantity humans: ");
            int amount = int.Parse(Console.ReadLine());
            Human[] hum = new Human[amount];
            for (int i = 0; i < amount; i++)
            {
                hum[i] = new Human();
                hum[i].Filling(i);
            }

            Choose(ref hum, ref amount);
            Console.ReadKey();
        }
        static void Choose(ref Human[] hum, ref int amount)
        {
            int num;
            do
            {
                Console.WriteLine("Enter number of object");
                num = int.Parse(Console.ReadLine());
                if (num <= amount && amount > 0)
                {
                    int value;
                    do
                    {
                        value = menu();
                        if (value == 1)
                        {
                            hum[num].delByIndex(ref hum, num, ref amount);
                            break;
                        }
                        else if (value == 2) hum[--num].GetInfo();
                        else if (value == 3) hum[--num].GetInfo(--num);
                        else if (value == 4) hum[--num].DisplayId();
                        else Console.WriteLine("Wrong input");

                    } while (value > 0);
                }
                else Console.WriteLine("Wrong input");
            } while (num > 0);
            
        }
        static int menu()
        {
            int val;
            Console.WriteLine("Choose what u want to do: ");
            Console.WriteLine("1. Delete object");
            Console.WriteLine("2. Get info");
            Console.WriteLine("3. Check object");
            Console.WriteLine("4. Get id");
            val = int.Parse(Console.ReadLine());
            return val;
        }
    }
}