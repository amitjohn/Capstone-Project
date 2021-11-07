using EnrollmentsService.Exceptions;
using EnrollmentsService.Model;
using EnrollmentsService.Models;
using EnrollmentsService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repo;

        public EnrollmentService(IEnrollmentRepository repo)
        {
            _repo = repo;
        }
        public void CreateProfile()
        {
            throw new NotImplementedException();
        }

        public bool AddEnrollment(Enrollment enrollment, DateTime startDate, DateTime endDate)
        {
            if (_repo.GetUserById(enrollment.EnrollmentId) != null)
                throw new EnrollmentAlreadyExistsException($"Enrollment {enrollment.EnrollmentId} Already Exists");
            return _repo.AddEnrollment(enrollment,startDate, endDate);
        }

        public bool checkMemberShipStatus(string id)
        {
            if (_repo.GetUserById(id) == null)
                throw new EnrollmentNotFoundException();
            return _repo.checkMemberShipStatus(id);
        }
        public Enrollment GetEnrolledMember(string id)
        {
            if (_repo.GetUserById(id) == null)
                throw new EnrollmentNotFoundException();
            return _repo.GetUserById(id);
        }
        public List<Enrollment> GetUserListByProgaramName(string programName)
        {
            return _repo.GetUsersByProgram(programName);
        }

        public bool UpdateEnrollmentDetails(string id, Enrollment enr)
        {
            if (_repo.GetUserById(id) == null)
                throw new EnrollmentNotFoundException();
            return _repo.UpdateEnrollmentDetails(id, enr);
        }

        public string UpdateMembershipName(string id, string MemberShipName)
        {
            if (_repo.GetUserById(id) == null)
                throw new EnrollmentNotFoundException();
            return _repo.UpdateMembershipName(id, MemberShipName);
        }

    }
}
