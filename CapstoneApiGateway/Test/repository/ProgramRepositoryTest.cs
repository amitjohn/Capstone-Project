using FitnessPrograms.Model;
using FitnessPrograms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.InfraSetup;
using Xunit;

namespace Test.repository
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class ProgramRepositoryTest : IClassFixture<ProgramsDbFixture>
    {
        private readonly IProgramsRepository repository;

        public ProgramRepositoryTest(ProgramsDbFixture _fixture)
        {
            this.repository = new ProgramsRepository(_fixture.context);
        }
        [Fact, TestPriority(1)]
        public void AddProgramsShouldSuccess()
        {
            Programs programs = new Programs { ProgramId = 3, ProgramName = "Premium", Price = 10999, Description = "What all does Premium Program Includes?" };
            var actual = repository.AddPrograms(programs);
            Assert.True(actual);
        }
        [Fact, TestPriority(2)]
        public void GetAllProgramsShouldSuccess()
        {
            var actual = repository.GetAllPrograms();
            Assert.IsAssignableFrom<List<Programs>>(actual);
            Assert.Contains(actual, c => c.ProgramName == "Basic");
        }
        [Fact, TestPriority(3)]
        public void GetProgramById()
        {
            var actual = repository.GetProgramById(1);
            Assert.NotNull(actual);
            Assert.Equal("Basic", actual.ProgramName);
        }
        [Fact, TestPriority(4)]
        public void GetProgramByName()
        {
            var actual = repository.GetProgramByName("Basic");
            Assert.NotNull(actual);
            Assert.Equal("Basic", actual.ProgramName);
        }
        [Fact, TestPriority(5)]
        public void DeleteProgramsShouldSuccess()
        {
            var actual = repository.DeletePrograms(3);
            Assert.True(actual);
        }
    }
}
