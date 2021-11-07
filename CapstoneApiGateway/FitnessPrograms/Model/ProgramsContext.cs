using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Model
{
    public class ProgramsContext 
    {
        IMongoClient client;
        IMongoDatabase database;
        public ProgramsContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration
            client = new MongoClient(configuration.GetSection("MongoDB").GetSection("ConnectionString").Value);
            database = client.GetDatabase(configuration.GetSection("MongoDB").GetSection("ProgramDatabase").Value);
        }

        //Define a MongoCollection to represent the Notes collection of MongoDB based on NoteUser type
        public IMongoCollection<Programs> Programs => database.GetCollection<Programs>("Programs");
    }
}
