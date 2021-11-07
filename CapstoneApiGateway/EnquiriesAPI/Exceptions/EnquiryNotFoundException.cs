using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Exceptions
{
    public class EnquiryNotFoundException : Exception
    {
        public EnquiryNotFoundException()
        {
        }

        public EnquiryNotFoundException(string message) : base(message)
        {
        }
    }
}
