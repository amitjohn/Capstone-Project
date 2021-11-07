
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Models
{
    public class EnquiryDataContext 
    {
        MongoClient client;
        IMongoDatabase db;

        public EnquiryDataContext(IConfiguration config)
        {
            var conf = config.GetSection("MongoDB");
            client = new MongoClient(conf.GetSection("ConnectionString").Value);
            db = client.GetDatabase(conf.GetSection("EnquiryDatabase").Value);
        }

        public IMongoCollection<Enquiry> Enquiries => db.GetCollection<Enquiry>("Enquiries");
    }
}
