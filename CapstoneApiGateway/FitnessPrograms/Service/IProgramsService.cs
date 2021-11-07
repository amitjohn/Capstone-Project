using FitnessPrograms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Service
{
    public interface IProgramsService
    {
        List<Programs> GetAllPrograms();
        Programs GetProgramById(int id);
        bool UpdateProgram(int id, Programs programs);
        bool AddPrograms(Programs programs);
        bool DeletePrograms(int id);
    }
}
