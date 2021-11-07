using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Exceptions
{
    public class EnrollmentNotFoundException : Exception
    {
        public EnrollmentNotFoundException()
        {
        }

        public EnrollmentNotFoundException(string message) : base(message)
        {
        }
    }
}
