using FitnessPrograms.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Repository
{
    public class ProgramsRepository : IProgramsRepository
    {
        private readonly ProgramsContext _db;
        public ProgramsRepository(ProgramsContext db)
        {
            _db = db;
        }

        public bool AddPrograms(Programs programs)
        {
            _db.Programs.InsertOne(programs);
            return true;
        }

        public bool DeletePrograms(int id)
        {
            var res = _db.Programs.DeleteOne(x => x.ProgramId == id);
            return res.IsAcknowledged;
        }

        public List<Programs> GetAllPrograms()
        {
            return _db.Programs.Find(x=>true).ToList();
        }

        public Programs GetProgramById(int id)
        {
            return _db.Programs.Find(x =>x.ProgramId == id).FirstOrDefault();
        }
        public Programs GetProgramByName(string Name)
        {
            return _db.Programs.Find(x => x.ProgramName.Equals(Name)).FirstOrDefault();
        }

        public bool UpdateProgram(int id, Programs programs)
        {//we are only allowing to update the description and Price
            var filter = Builders<Programs>.Filter.Where(x=>x.ProgramId == id);
            var update = Builders<Programs>.Update
                .Set(x => x.Price, programs.Price)
                .Set(x=>x.Description, programs.Description);
            var res = _db.Programs.UpdateOne(filter,update);
            return res.IsAcknowledged;
        }
    }
}
