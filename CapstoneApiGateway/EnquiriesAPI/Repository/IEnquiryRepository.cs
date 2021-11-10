using EnquiriesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Repository
{
    public interface IEnquiryRepository
    {
        Enquiry PostEnquiry(Enquiry enquiry);
        Enquiry GetEnquiryById(int id);
        List<Enquiry> GetEnquiries();

        bool DeleteEnquiry(int id);

        bool EnquiryStatusUpdate(int id, string Remarks);

        //List<Enquiry> GetNotResolvedEnquiries(bool b);
    }
}
