using EnrollmentsService.Model;
using EnrollmentsService.Repository;
using EnrollmentsService.Service;
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
    public class EnrollmentServiceTest
    {
        [Fact, TestPriority(1)]
        public void CreateCategoryShouldReturnCategory()
        {
            var mockRepo = new Mock<IEnrollmentRepository>();
            Enrollment enrollment = new Enrollment { EnrollmentId = "GOLD012", Name = "Bonny M", ProgramName = "Premium", ProgramCost = 10999, Email = "bonnym@gmail.com", ContactNo = "2222222223", MembershipStatus = true };
            DateTime start = DateTime.Now.Date;
            DateTime end = new DateTime(2021-01-01);
            mockRepo.Setup(repo => repo.AddEnrollment(enrollment, start, end)).Returns(true);
            var service = new EnrollmentService(mockRepo.Object);

            var actual = service.AddEnrollment(enrollment, start, end);

            Assert.True(actual);
        }
    }
}
