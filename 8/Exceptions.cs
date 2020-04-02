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
}    
