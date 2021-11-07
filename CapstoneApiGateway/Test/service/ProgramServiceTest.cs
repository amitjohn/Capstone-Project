using FitnessPrograms.Model;
using FitnessPrograms.Repository;
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
    public class ProgramServiceTest
    {
        [Fact, TestPriority(1)]
        public void CreateCategoryShouldReturnCategory()
        {
            var mockRepo = new Mock<IProgramsRepository>();
            Programs programs = new Programs { ProgramId = 3, ProgramName = "Premium", Price = 10999, Description = "What all does Premium Program Includes?" };
            mockRepo.Setup(repo => repo.AddPrograms(programs)).Returns(true);
            var service = new FitnessPrograms.Service.ProgramsService(mockRepo.Object);
            var actual = service.AddPrograms(programs);
            Assert.True(actual);
        }
        [Fact, TestPriority(2)]
        public void GetProgramByIdShouldSuccess()
        {
            var mockRepo = new Mock<IProgramsRepository>();
            var Id = 2;
            Programs programs = new Programs { ProgramId = 3, ProgramName = "Premium", Price = 10999, Description = "What all does Premium Program Includes?" };

            mockRepo.Setup(repo => repo.GetProgramById(Id)).Returns(programs);
            var service = new FitnessPrograms.Service.ProgramsService(mockRepo.Object);

            var actual = service.GetProgramById(Id);

            Assert.IsAssignableFrom<Programs>(actual);
            Assert.Equal(programs.ProgramName, actual.ProgramName);
        }
    }
}
