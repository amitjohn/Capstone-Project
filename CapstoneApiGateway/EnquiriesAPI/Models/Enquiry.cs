using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Models
{
    public class Enquiry
    {   [BsonId]
        public int EnquiryId { get; set; }
        public string Description { get; set; }
        public string ContactNo { get; set; }
        public string Name { get; set; }
        public string EnquiryType { get; set; }
        public string Email { get; set; }
        public bool IsResolved { get; set; }
    }
}
