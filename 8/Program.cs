using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addfuncs
{
    class StudentException : ArgumentException
    {
        public int Value { get; }
        public StudentException(string message, int val)
            : base(message)
        {
            Value = val;
        }

        public double Number { get; }
        public StudentException(string message, double num)
            : base(message)
        {
            Number = num;
        }

    }
    interface IMyInterfaceFirst
    {
        void GetInfo();
    }
    interface IMyInterfaceSec : IMyInterfaceFirst
    {
        string GetOlimpiad();
    }
    public interface IComparable
    {
        int CompareTo(object obj);
    }

    abstract class Human : IMyInterfaceFirst
    {
        public String Name { get; set; }
        public String Country { get; set; }
        //public int YearOfBirth { get; set; }
        public int YearOfBirth
        {
            get { return YearOfBirth; }
            set
            {
                if (value < 17)
                {
                    throw new StudentException("Лицам до 18 регистрация запрещена", value);
                }
                else
                {
                    YearOfBirth = value;
                }
            }
        }


        protected static int counter { get; set; }

        public Human()
        {
            Name = "Dany Ryaby";
            Country = "Belarus";
            YearOfBirth = 2002;
            counter++;
        }
        public Human(string name, string country, int yearofbirth)
        {
            Name = name;
            Country = country;
            YearOfBirth = yearofbirth;
            counter++;
        }
        ~Human()
        {
            Name = null;
            YearOfBirth = 0;
            Country = null;
            counter = 0;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {Name}\tYear of birth: {YearOfBirth}\t" +
                $"Country: {Country}\nUnique id of object Human is  {counter}");
        }
    }
    abstract class Spec : Human
    {
        public String Speciality { get; set; }

        public Spec() : base()
        {
            Speciality = "Informatics and technologies of programming";
        }

        public Spec(string name, string country, int yearofbirth, string speciality) : base(name, country, yearofbirth)
        {
            Speciality = speciality;
        }

    }
    class Student : Spec, IMyInterfaceSec, IComparable<Student>
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler _notify;
        public event AccountHandler Notify
        {
            add
            {
                _notify += value;
                Console.WriteLine($"{value.Method.Name} added");
            }
            remove
            {
                _notify -= value;
                Console.WriteLine($"{value.Method.Name} deleted");
            }
        }

        public Int32 YearOfEntrance { get; set; }
        public Int32 EntrancePoints
        {
            get { return EntrancePoints; }
            set {
                if (value > 400 || value < 0)  throw new StudentException("Need to be between 0 and 400", value);
                else EntrancePoints = value;
            }
        }
        public double AverageMark
        {
            get { return AverageMark; }
            set
            {
                if (value > 10 || value < 0) throw new StudentException("You input wrong marks", value);
                else AverageMark = value;
            }
        }
public enum Olimpiads
        {
            NoOne = 1,
            Math,
            Physics,
            Informatics,
            Russian,
            Belarussian,
            English,
            Geography,
            History,
            Chemistry
        }
        public Olimpiads Oly;
        public struct NextOlimpiad
        {
            public string name;
            public DateTime date1;
        }
        public NextOlimpiad nxtOly;
        public int CompareTo(Student obj)
        {
            _notify?.Invoke($"Sorted.");
            if (this.EntrancePoints == obj.EntrancePoints) return 0;
            else if (this.EntrancePoints > obj.EntrancePoints) return 1;
            else return -1;
        }

        public Student() : base()
        {
            YearOfEntrance = 2019;
            EntrancePoints = 368;
            AverageMark = 9.25;
            Oly = Olimpiads.Physics;
            nxtOly.name = "olimpiad";
            nxtOly.date1 = new DateTime(2020, 11, 8);
        }
        public Student(string name, string country, int yearofbirth, string speciality, int entranceyear, int points, double avmark, Olimpiads oly = default, DateTime date = default)
            : base(name, country, yearofbirth, speciality)
        {

            YearOfEntrance = entranceyear;
            EntrancePoints = points;
            AverageMark = avmark;
            Oly = oly;
            nxtOly.name = "olimpiad";
            nxtOly.date1 = date;
        }
        ~Student()
        {
            YearOfEntrance = 0;
            EntrancePoints = 0;
            AverageMark = 0;
            Oly = default;
            nxtOly.name = null;
        }
        public string GetOlimpiad()
        {
            string str;
            if (Oly == Olimpiads.Math) str = "mathematics";
            else if (Oly == Olimpiads.NoOne) str = "no one";
            else if (Oly == Olimpiads.Physics) str = "physics";
            else if (Oly == Olimpiads.Geography) str = "geography";
            else if (Oly == Olimpiads.History) str = "history";
            else if (Oly == Olimpiads.English) str = "english";
            else if (Oly == Olimpiads.Chemistry) str = "chemistry";
            else if (Oly == Olimpiads.Informatics) str = "informatics";
            else if (Oly == Olimpiads.Russian) str = "russian";
            else str = "belarussian";
            return str;
        }
        public override void GetInfo()
        {
            _notify?.Invoke($"------------Information about student-----------");
            Console.WriteLine($"Name: {Name}\n" +
                $"Country: {Country}\n" +
                $"Speciality: {Speciality}\n" +
                $"Year of entrance: {YearOfEntrance}\n" +
                $"Entrance points: {EntrancePoints}\n" +
                $"Olimpiad: {GetOlimpiad()}\n" +
                $"Last exams average mark: {AverageMark}\n" +
                $"Next {nxtOly.name} in university will be at {nxtOly.date1}.");
        }

        //public delegate void Del(string message);

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student objf = new Student();
            Student objs = new Student("Nikolai", "Spain", 2001, "Automated information processing systems", 2018, 355, 8.5, Student.Olimpiads.Informatics, new DateTime(2020, 08, 01));
            var objth = SetStudent();
            Console.Clear();

            objf.Notify += DisplayRedMessage;
            objf.GetInfo();

            objs.Notify += message => Console.WriteLine(message); //лямбда-выражениe
            objs.GetInfo();

            objth.Notify += delegate (string message) //анонимный метод
            {
                Console.WriteLine(message);
            };
            objth.GetInfo();



            try
            {
                Student[] students = new Student[2];
                SetStudList(students);

                //Student.Del handler = DelegateMethod;

                Array.Sort(students);
                foreach (Student ob in students)
                {
                    Console.WriteLine($"{ob.Name} - {ob.EntrancePoints}");
                }
            }
            catch (StudentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            Console.Read();

        }

        public static void SetStudList(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
                students[i] = SetStudent();
            Console.Clear();
            /*Console.WriteLine("List of students:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i]);*/
        }

        private static void DisplayRedMessage(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static Student SetStudent()
        {
            Console.Write("Enter students`s surame: ");
            string name = Console.ReadLine();
            Console.Write("Enter students`s country name: ");
            string country = Console.ReadLine();
            Console.Write("Enter students`s year of birth: ");
            int YearOfBirth = int.Parse(Console.ReadLine());

            Console.Write("Enter students`s speciality: ");
            string spec = Console.ReadLine();

            Console.Write("Enter students`s year of entrance: ");
            int YearOfEntrance = int.Parse(Console.ReadLine());
            Console.Write("Enter  students`s entrance points: ");
            int EntrancePoints = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter general subjects marks");
            int[] UniversityMarks = new int[4];
            for (int i = 0; i < UniversityMarks.Length; i++)
            {
                Console.Write("Mark № {0} ", i + 1);
                UniversityMarks[i] = int.Parse(Console.ReadLine());
            }
            int averagemark = 0;
            for (int i = 0; i < UniversityMarks.Length; i++)
            {
                averagemark += UniversityMarks[i];
            }
            averagemark /= UniversityMarks.Length;

            Console.Write("Enter student`s olympiad:" +
                "(1 - No one, 2 - Math, 3 - Physics, 4 - Informatics, 5 - Russian," +
                " 6 - Belarussian, 7 - English, 8 - Geography, 9 - History): ");
            int oly = CheckOly();

            Console.Write("Enter the date of olimpiad: ");
            DateTime date = CheckDate();

            return new Student(name, country, YearOfBirth, spec, EntrancePoints, EntrancePoints, averagemark, (Student.Olimpiads)oly, date);
        }
        public static DateTime CheckDate()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
                Console.Write("Incorrect input, repeat: ");
            return date;
        }
        public static int CheckOly()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > 9)
                Console.Write("Incorrect input, repeat: ");
            return a;
        }
        /*public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }*/
    }
}
