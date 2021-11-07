using EnquiriesAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.InfraSetup
{
    public class EnquiryDbFixture : IDisposable
    {
        private IConfigurationRoot configuration;
        public EnquiryDataContext context;
        public EnquiryDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            configuration = builder.Build();
            context = new EnquiryDataContext(configuration);
            context.Enquiries.DeleteMany(Builders<Enquiry>.Filter.Empty);
            context.Enquiries.InsertMany(new List<Enquiry>
            {
                new EnquiriesAPI.Models.Enquiry{EnquiryId=1,Name="Dino James", ContactNo="1234567890",Description="A man with a plan", Email="dinojames@gmail.com",EnquiryType="Cost"},
                new EnquiriesAPI.Models.Enquiry{ EnquiryId=2, Name="Elon Gates", ContactNo="0987654321",Description="A man with no plan", Email="elongates@gmail.com",EnquiryType="Program"}
            });
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
