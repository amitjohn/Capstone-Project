using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Exceptions
{
    public class EnquiryAlradyExistsException : Exception
    {
        public EnquiryAlradyExistsException()
        {
        }

        public EnquiryAlradyExistsException(string message) : base(message)
        {
        }
    }
}
