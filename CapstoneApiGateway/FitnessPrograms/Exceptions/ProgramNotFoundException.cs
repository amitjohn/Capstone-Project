using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Exceptions
{
    public class ProgramNotFoundException : Exception
    {
        public ProgramNotFoundException(string message) : base(message)
        {
        }
    }
}
