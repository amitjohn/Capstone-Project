using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Exceptions
{
    public class ProgramAlreadyExistsException : Exception
    {
        public ProgramAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
