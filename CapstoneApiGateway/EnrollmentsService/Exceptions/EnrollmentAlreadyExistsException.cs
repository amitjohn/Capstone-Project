using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Exceptions
{
    public class EnrollmentAlreadyExistsException : Exception
    {
        public EnrollmentAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
