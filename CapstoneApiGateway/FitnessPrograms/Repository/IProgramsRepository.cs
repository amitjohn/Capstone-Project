using FitnessPrograms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Repository
{
    public interface IProgramsRepository
    {
        List<Programs> GetAllPrograms();
        Programs GetProgramById(int id);
        Programs GetProgramByName(string Name);
        bool UpdateProgram(int id, Programs programs);
        bool AddPrograms(Programs programs);
        bool DeletePrograms(int id);
    }
}
