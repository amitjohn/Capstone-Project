using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public class EnrollmentRepository:IEnrollmentRepository
    {
        private readonly DataContext _db;

        public EnrollmentRepository(DataContext db)
        {
            this._db = db;
        }

        public bool AddEnrollment(Enrollment enroll, DateTime startDate, DateTime endDate)
        {
            enroll.MembershipStatus = false;
            _db.Enrollments.Add(enroll);
            _db.History.Add(new MembershipHistory() { 
                EnrollmentId = enroll.EnrollmentId, 
                StartDate = startDate, 
                EndDate = endDate });
            return Convert.ToBoolean(_db.SaveChanges());
        }

        public List<Enrollment> GetUsersByProgram(string programName)
        {    
            return _db.Enrollments.Where(x => x.ProgramName.Equals(programName)).ToList();
        }
        public Enrollment GetUserById(string id)
        {
            return _db.Enrollments.Where(x => x.EnrollmentId == id).FirstOrDefault();
        }

        public bool UpdateEnrollmentDetails(string id,Enrollment enr)
        {
            //not allowing to update EndDate from here, use updateMemberShip() to update EndDate
            var res = _db.Enrollments.Where(x => x.EnrollmentId == id).FirstOrDefault();
            res.ProgramName = enr.ProgramName;
            res.ProgramCost = enr.ProgramCost;
            res.Name = enr.Name;
            res.ContactNo = enr.ContactNo;
            res.Email = enr.Email;
            _db.Entry<Enrollment>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Convert.ToBoolean(_db.SaveChanges());
        }

        public bool checkMemberShipStatus(string id)
        {
            Enrollment res = _db.Enrollments.Where(x => x.EnrollmentId == id).FirstOrDefault();
            return res.MembershipStatus;
        }

        public string UpdateMembershipName(string id, string ProgramName)
        {
            var res = _db.Enrollments.Where(x => x.EnrollmentId == id).FirstOrDefault();
            res.ProgramName = ProgramName;
            _db.Entry<Enrollment>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return res.ProgramName;
        }
    }
}
