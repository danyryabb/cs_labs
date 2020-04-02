using System;

namespace ung
{
    class Program
    {
        static void Main(string[] args)
        {
            Student objf = new Student();
            Student objs = new Student("Nikolai","Spain", 2001, "Automated information processing systems", 2018, 355, 8.5, Student.Olimpiads.Informatics, new DateTime(2020, 08, 01));
            var objth = SetStudent();
            Console.Clear();
            
            objf.GetInfo();
            objs.GetInfo();
            objth.GetInfo();

            Student[] students = new Student[2];
            SetStudList(students);
        }
        public static void SetStudList(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
                students[i] = SetStudent();
            Console.Clear();
            Console.WriteLine("List of students:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i]);
        }

        public static Student SetStudent()
        {
            Console.Write("Enter students`s surame: ");
            do{
            string name = Console.ReadLine();
            }while(StrCheck(name) == false);
            
            Console.Write("Enter students`s country name: ");
            do{
            string country = Console.ReadLine();
            }while(StrCheck(country) == false);
            
            Console.Write("Enter students`s year of birth: ");
            int YearOfBirth = CheckInt();

            Console.Write("Enter students`s speciality: ");
            do{
            string spec = Console.ReadLine();
            }while(StrCheck(spec) == false);

            Console.Write("Enter students`s year of entrance: ");
            int YearOfEntrance = CheckInt();
            
            Console.Write("Enter  students`s entrance points: ");
            int EntrancePoints = CheckInt();
            
            Console.WriteLine("Enter general subjects marks");
            int[] UniversityMarks = new int[4];
            for (int i = 0; i < UniversityMarks.Length; i++)
            {
                Console.Write("Mark № {0} ", i + 1);
                do{
                UniversityMarks[i] = CheckInt();
                }while(UnUniversityMarks[i] < 0 || UniversityMarks[i] > 10 )
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
        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.Write("Incorrect data, repeat: ");
            return a;
        }
        public static bool StrCheck(string field)
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
