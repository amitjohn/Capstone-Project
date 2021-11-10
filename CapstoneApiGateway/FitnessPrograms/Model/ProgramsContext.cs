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
            string server = Environment.GetEnvironmentVariable("Mongo_DB");
            string db_name = Environment.GetEnvironmentVariable("DB_NAME");
            if (server == null)
            {
                server = configuration.GetSection("MongoDB").GetSection("ConnectionString").Value;
            }
            if (db_name == null)
            {
                db_name = configuration.GetSection("MongoDB").GetSection("ProgramDatabase").Value;
            }
            //Initialize MongoClient and Database using connection string and database name from configuration
            client = new MongoClient(server);
            database = client.GetDatabase(db_name);
        }

        //Define a MongoCollection to represent the Notes collection of MongoDB based on NoteUser type
        public IMongoCollection<Programs> Programs => database.GetCollection<Programs>("Programs");
    }
}
