using EnquiriesAPI.Models;
using EnrollmentsService;
using FitnessPrograms.Model;
using GymUserApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.InfraSetup;
using Xunit;
namespace Test
{
    public class EnquiryWebApplicationFactory<TStartup> : WebApplicationFactory<EnquiriesAPI.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<EnquiryDataContext>();
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<EnquiryDataContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<EnquiryWebApplicationFactory<TStartup>>>();

                    try
                    {
                        // Seed the database with some specific test data.
                        context.Enquiries.DeleteMany(Builders<EnquiriesAPI.Models.Enquiry>.Filter.Empty);
                        context.Enquiries.InsertMany(new List<EnquiriesAPI.Models.Enquiry>
            {
                new EnquiriesAPI.Models.Enquiry{EnquiryId=1,Name="Dino James", ContactNo="1234567890",Description="A man with a plan", Email="dinojames@gmail.com",EnquiryType="Cost"},
                 new EnquiriesAPI.Models.Enquiry{ EnquiryId=2, Name="Elon Gates", ContactNo="0987654321",Description="A man with no plan", Email="elongates@gmail.com",EnquiryType="Program"}
            });
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
    public class ProgramsWebApplicationFactory<TStartup> : WebApplicationFactory<FitnessPrograms.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ProgramsContext>();
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<ProgramsContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<ProgramsWebApplicationFactory<TStartup>>>();

                    try
                    {
                        // Seed the database with some specific test data.
                        context.Programs.DeleteMany(Builders<FitnessPrograms.Model.Programs>.Filter.Empty);
                        context.Programs.InsertMany(new List<FitnessPrograms.Model.Programs>{
                        new FitnessPrograms.Model.Programs{ProgramId=1, ProgramName="Basic", Price=3999, Description="What all does Basic Program Includes?"},
                        new FitnessPrograms.Model.Programs{ProgramId=2, ProgramName="Standard", Price=5999, Description="What all does Standard Program Includes?"}
                            });
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
    public class EnrollmentWebApplicationFactory<TStartup> : WebApplicationFactory<EnrollmentsService.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (KeepNoteContext) using an in-memory database for testing.
                services.AddDbContext<EnrollmentsService.Model.DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryNoteDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var EnrollmentDb = scopedServices.GetRequiredService<EnrollmentsService.Model.DataContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<EnrollmentWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    EnrollmentDb.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with some specific test data.
                        SeedData.PopulateTestData(EnrollmentDb);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }

    public class AuthWebApplicationFactory<TStartup> : WebApplicationFactory<GymUserApi.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context using an in-memory database for testing.
                services.AddDbContext<UserDbContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName:"InMemoryAuthDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var authDb = scopedServices.GetRequiredService<UserDbContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<AuthWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    authDb.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with some specific test data.
                        //IdentityUser user = new IdentityUser { UserName = "Eminem", PasswordHash = "Eminem@123" };
                        //authDb.Users.Add(user);
                        //authDb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }

    [CollectionDefinition("Auth API")]
    public class DbCollection : ICollectionFixture<AuthWebApplicationFactory<GymUserApi.Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
