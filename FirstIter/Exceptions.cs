using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstIteration
{
    public class InvalidRomanNumberalException : Exception
    {
        public InvalidRomanNumberalException(string message) : base(message) { }
    }

    public class InvalidRomanNumeralSequenceException : Exception
    {
        public InvalidRomanNumeralSequenceException(string message) : base(message) { }
    }

    public class ExcessiveRepetitionException : Exception
    {
        public ExcessiveRepetitionException(string message) : base(message) { }
    }
}
