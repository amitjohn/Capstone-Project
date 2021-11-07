using EnquiriesAPI.Models;
using EnquiriesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using Test.InfraSetup;
using Xunit;

namespace Test.repository
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class EnquiryRepositoryTest :IClassFixture<EnquiryDbFixture>
    {
        private IEnquiryRepository repository;

        public EnquiryRepositoryTest(EnquiryDbFixture _fixture)
        {
            this.repository = new EnquiryRepository(_fixture.context);
        }
        [Fact, TestPriority(1)]
        public void PostEnquiryShouldReturnEnquiry()
        {
            Enquiry enquiry = new Enquiry { EnquiryId = 3, Name = "Ali baba", ContactNo = "0987654333", Description = "A man with many plan", Email = "alibaba@gmail.com", EnquiryType = "Cost", IsResolved=false };
            var actual = repository.PostEnquiry(enquiry);
            Assert.IsAssignableFrom<Enquiry>(actual);
            Assert.Equal(enquiry.EnquiryId, actual.EnquiryId);
        }
        [Fact, TestPriority(2)]
        public void GetEnquiryByIdShouldReturnEnquiry()
        {
            var actual = repository.GetEnquiryById(2);
            Assert.IsAssignableFrom<Enquiry>(actual);
            Assert.Equal("Elon Gates", actual.Name);
        }
        [Fact, TestPriority(3)]
        public void GetEnquiriesShouldReturnEnquiries()
        {
            var actual = repository.GetEnquiries();
            Assert.IsAssignableFrom<List<Enquiry>>(actual);
            Assert.Contains(actual, e => e.Email == "elongates@gmail.com");
        }
        [Fact, TestPriority(4)]
        public void EnquiryStatusUpdateShouldSuccess()
        {
            Enquiry enquiry = new Enquiry { EnquiryId = 3, Name = "Ali baba", ContactNo = "0987654333", Description = "A man with few plan", Email = "alibaba@gmail.com", EnquiryType = "Cost", IsResolved = false };
            var actual = repository.EnquiryStatusUpdate(enquiry.EnquiryId);
            Assert.True(actual);
        }
    }
}
