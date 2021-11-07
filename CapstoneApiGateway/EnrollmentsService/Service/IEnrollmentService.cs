using EnrollmentsService.Model;
using EnrollmentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public interface IEnrollmentService
    {
        public bool AddEnrollment(Enrollment enroll, DateTime startDate, DateTime endDate);
        void CreateProfile();
        Enrollment GetEnrolledMember(string id);
        List<Enrollment> GetUserListByProgaramName(string programName); // not dealing with Enrollment Database
        bool checkMemberShipStatus(string id);
        
        string UpdateMembershipName(string id, String Name);
        bool UpdateEnrollmentDetails(string id, Enrollment enr);
    }
}
