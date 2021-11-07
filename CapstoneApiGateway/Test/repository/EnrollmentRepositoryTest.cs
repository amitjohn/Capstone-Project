using EnrollmentsService.Model;
using EnrollmentsService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.InfraSetup;
using Xunit;

namespace Test.repository
{
    [Collection("Database collection")]
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class EnrollmentRepositoryTest
    {
        EnrollmentRepository repository;
        public EnrollmentRepositoryTest(EnrollmentDbFixture databaseFixture)
        {
            repository = new EnrollmentRepository(databaseFixture.context);
        }
        [Fact, TestPriority(1)]
        public void CreateCategoryShouldSuccess()
        {
            DateTime start = new DateTime(2021-09-01).Date;
            DateTime end = new DateTime(2022 - 01 - 01);
            Enrollment enrollment = new Enrollment { EnrollmentId = "GOLD012", Name = "Joney Bones", ProgramName = "Premium", ProgramCost = 10999, Email = "joneybones@gmail.com", ContactNo = "3333333333", MembershipStatus = true };
           
            var actual = repository.AddEnrollment(enrollment, start, end);
            Assert.True(actual);
        }
    }
}
