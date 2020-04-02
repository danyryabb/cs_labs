using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addfuncs
{
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
} 
