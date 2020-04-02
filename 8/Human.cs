using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addfuncs
{
    abstract class Human : IMyInterfaceFirst
    {
        public String Name { get; set; }
        public String Country { get; set; }
        public int YearOfBirth { get; set; }
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
        public override string ToString() => $"Surame: {Name}\tYear of birth: {YearOfBirth}\t" +
                $"Country: {Country}\tUnique id of object Human is  {counter}";
        }
    }
}    
