using FitnessPrograms.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.InfraSetup
{
    public class ProgramsDbFixture :IDisposable
    {
        private IConfigurationRoot configuration;
        public ProgramsContext context;
        public ProgramsDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.test.json");

            configuration = builder.Build();
            context = new ProgramsContext(configuration);
            context.Programs.DeleteMany(Builders<Programs>.Filter.Empty);
            context.Programs.InsertMany(new List<Programs>
            {
                new FitnessPrograms.Model.Programs{ProgramId=1, ProgramName="Basic", Price=3999, Description="What all does Basic Program Includes?"},
                new FitnessPrograms.Model.Programs{ProgramId=2, ProgramName="Standard", Price=5999, Description="What all does Standard Program Includes?"}
            });
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
