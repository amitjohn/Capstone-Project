using FitnessPrograms.Exceptions;
using FitnessPrograms.Model;
using FitnessPrograms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Service
{
    public class ProgramsService : IProgramsService
    {
        private readonly IProgramsRepository _repo;

        public ProgramsService(IProgramsRepository repository)
        {
            _repo = repository;
        }

        public bool AddPrograms(Programs programs)
        {
            if (_repo.GetProgramByName(programs.ProgramName) != null)
                throw new ProgramAlreadyExistsException($"{programs.ProgramName} already Exists");
            return _repo.AddPrograms(programs);
        }

        public bool DeletePrograms(int id)
        {
            if (_repo.GetProgramById(id) == null)
                throw new ProgramNotFoundException($"Program {id} not found");
            return _repo.DeletePrograms(id);
        }

        public List<Programs> GetAllPrograms()
        {
            return _repo.GetAllPrograms();
        }

        public Programs GetProgramById(int id)
        {
            var res = _repo.GetProgramById(id);
            if (res == null)
                throw new ProgramNotFoundException($"Program {id} not found");
            return res;
        }

        public bool UpdateProgram(int id, Programs programs)
        {
            if (_repo.GetProgramById(id) == null)
                throw new ProgramNotFoundException($"Program {id} not found");
            return _repo.UpdateProgram(id, programs);
        }
    }
}
