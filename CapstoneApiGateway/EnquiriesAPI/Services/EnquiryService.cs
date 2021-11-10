using EnquiriesAPI.Exceptions;
using EnquiriesAPI.Models;
using EnquiriesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryRepository repo;

        public EnquiryService(IEnquiryRepository repo)
        {
            this.repo = repo;
        }

        public bool DeleteEnquiry(int id)
        {
            var res = repo.GetEnquiryById(id);
            if(res == null)
            {
                throw new EnquiryNotFoundException("Enquiry Id Not Exists");
            }
            return repo.DeleteEnquiry(id);
        }

        public bool EnquiryStatusUpdate(int id, string Remarks)
        {
            var res = repo.GetEnquiryById(id);
            if(res == null)
            {
                throw new EnquiryNotFoundException("Enquiry Id Not Exists");
            }
             return repo.EnquiryStatusUpdate(id, Remarks);
        }

        public List<Enquiry> GetEnquiries()
        {
            return repo.GetEnquiries();
        }

        public Enquiry GetEnquiryById(int id)
        {
            var res = repo.GetEnquiryById(id);
            if(res == null)
            {
                throw new EnquiryNotFoundException("Enquiry Id Not Exists");
            }
            return repo.GetEnquiryById(id);
        }

        public Enquiry PostEnquiry(Enquiry enquiry)
        {
            var res = repo.GetEnquiryById(enquiry.EnquiryId);
            if(res != null)
            {
                throw new EnquiryAlradyExistsException("This Id Already Exists..");
            }
            return repo.PostEnquiry(enquiry);
        }
    }
}
