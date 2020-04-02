using System;

namespace ClassCreating
{
   public class Human
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string SchoolName { get; set; }
        public int YearOfBirth { get; set; }
        private static int counter { get; set; }


        public Human()
        {
            SecondName = "Ryaby";
            FirstName = "Dany";
            YearOfBirth = 2002;
            PlaceOfBirth = "Luban";
            SchoolName = "Gumnasium N1";
            counter++;
        }
        public Human(string sname, string fname, string pname, string schname, int year)
        {
            SecondName = sname;
            FirstName = fname;
            YearOfBirth = year;
            PlaceOfBirth = pname;
            SchoolName = schname;
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
            do
            {
                SecondName = Console.ReadLine();
            } while (StrCheck(SecondName) == false);
            Console.WriteLine($"Enter {index} human`s 1st name: ");
            do
            {
                FirstName = Console.ReadLine();
            } while (StrCheck(FirstName) == false);
            Console.WriteLine($"Enter {index} human`s place of birth: ");
            do
            {
                PlaceOfBirth = Console.ReadLine();
            } while (StrCheck(PlaceOfBirth) == false);
            Console.WriteLine($"Enter {index} human`s school name: ");
            do
            {
                SchoolName = Console.ReadLine();
            } while (StrCheck(SchoolName) == false);
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
        public bool StrCheck(string field)
        {
            bool flag = false;
            int counter = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] > 32 && field[i] < 65 && field[i] > 90 && field[i] < 97 && field[i] > 122)
                {
                    counter++;
                }
            }
            if (counter != 0) flag = false;
            else flag = true;
            return flag;
        }
    }
}
