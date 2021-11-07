using EnrollmentsService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.InfraSetup
{
    public class EnrollmentDbFixture
    {
        public DataContext context;

        public EnrollmentDbFixture()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "EnrollmentsTestDb")
                .Options;

            //Initializing DbContext with InMemory
            context = new DataContext(options);

            // Insert seed data into the database using one instance of the context
            SeedData.PopulateTestData(context);
        }
        public void Dispose()
        {
            context = null;
        }
        [CollectionDefinition("Database collection")]
        public class DatabaseCollection : ICollectionFixture<EnrollmentDbFixture>
        {
            // This class has no code, and is never created. Its purpose is simply
            // to be the place to apply [CollectionDefinition] and all the
            // ICollectionFixture<> interfaces.
        }
    }
}
