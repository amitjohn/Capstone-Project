using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Exceptions
{
    public class UserProfileNotFoundException : Exception
    {
        public UserProfileNotFoundException(string message) : base(message)
        {
        }
    }
}
