using EnquiriesAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Repository
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly EnquiryDataContext db;
        public EnquiryRepository(EnquiryDataContext db)
        {
            this.db = db;
        }

        public bool DeleteEnquiry(int id)
        {
            db.Enquiries.DeleteOne(x => x.EnquiryId == id);
            return true;

        }

        public List<Enquiry> GetEnquiries()
        {
            return db.Enquiries.Find(x => true).ToList();
        }

        public Enquiry GetEnquiryById(int id)
        {
            var res = db.Enquiries.Find(x => x.EnquiryId == id).FirstOrDefault();
            return res;
        }

        public Enquiry PostEnquiry(Enquiry enquiry)
        {
            db.Enquiries.InsertOne(enquiry);
            return db.Enquiries.Find(x=>x.EnquiryId == enquiry.EnquiryId).FirstOrDefault();
        }

        public bool EnquiryStatusUpdate(int id, string Remarks)
        {
            var filters = Builders<Enquiry>.Filter.Where(x => x.EnquiryId == id);
            var update = Builders<Enquiry>.Update.Set(x => x.IsResolved, true)
                .Set(x=>x.Remarks, Remarks);
             db.Enquiries.UpdateOne(filters, update);
            return true;
        }
      
    }
}
