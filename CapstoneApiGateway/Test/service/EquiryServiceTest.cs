using EnquiriesAPI.Exceptions;
using EnquiriesAPI.Models;
using EnquiriesAPI.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.service
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class EquiryServiceTest
    {
        #region Positive tests
        [Fact, TestPriority(1)]
        public void PostEnquiryShouldReturnEnquiry()
        {
            var mockRepo = new Mock<IEnquiryRepository>();
            Enquiry enquiry = new Enquiry { EnquiryId = 10, Name = "Vitalik Buterin", ContactNo = "0987633333", Description = "A man with Crypto", Email = "vitalikbuterin@gmail.com", EnquiryType = "Cost", IsResolved = false };
            //mockRepo.Setup(repo => repo.GetEnquiryById(10)).Returns(enquiry);
            mockRepo.Setup(repo => repo.PostEnquiry(enquiry)).Returns(enquiry);
            var service = new EnquiriesAPI.Services.EnquiryService(mockRepo.Object);

            var actual = service.PostEnquiry(enquiry);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Enquiry>(actual);
        }
        #endregion Positive tests
        #region Negative tests
        [Fact, TestPriority(2)]
        public void PostEnquiryShouldThrowException()
        {
            var mockRepo = new Mock<IEnquiryRepository>();
            Enquiry enquiry = new Enquiry { EnquiryId = 1, Name = "Dino James", ContactNo = "1234567890", Description = "A man with a plan", Email = "dinojames@gmail.com", EnquiryType = "Cost" };
            mockRepo.Setup(repo => repo.GetEnquiryById(1)).Returns(enquiry);
            List<Enquiry> categories = new List<Enquiry>();
            var service = new EnquiriesAPI.Services.EnquiryService(mockRepo.Object);
            var actual = Assert.Throws<EnquiryAlradyExistsException>(()=>service.PostEnquiry(enquiry));
            Assert.Equal("This Id Already Exists..", actual.Message);
        }
        #endregion Negative tests
    }
}
