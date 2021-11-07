using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public interface IEnrollmentRepository
    {
        public bool AddEnrollment(Enrollment enroll, DateTime startDate, DateTime endDate);
        bool checkMemberShipStatus(string id);
        string UpdateMembershipName(string id, String name);
        bool UpdateEnrollmentDetails(string id, Enrollment enr);

        List<Enrollment> GetUsersByProgram(string programName);
        public Enrollment GetUserById(string id);
    }
}
