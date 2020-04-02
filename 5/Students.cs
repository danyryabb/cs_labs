using System;

namespace ung
{
    class Student : Spec
    {
        public Int32 YearOfEntrance { get; set; }
        public Int32 EntrancePoints { get; set; }
        public double AverageMark { get; set; }
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
        public override string ToString() => $"Name: {Name}\n" +
                $"Country: {Country}\n" +
                $"Speciality: {Speciality}\n" +
                $"Year of entrance: {YearOfEntrance}\n" +
                $"Entrance points: {EntrancePoints}\n" +
                $"Olimpiad: {GetOlimpiad()}\n" +
                $"Last exams average mark: {AverageMark}\n" +
                $"Next {nxtOly.name} in university will be at {nxtOly.date1}.";
    }
}
