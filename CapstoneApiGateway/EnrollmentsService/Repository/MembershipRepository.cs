using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly DataContext _db;

        public MembershipRepository(DataContext db)
        {
            _db = db;
        }

        public bool UpdateMembershipPeriod(MembershipHistory history)
        {
            var res = _db.History.Where(x => x.EnrollmentId == history.EnrollmentId).FirstOrDefault();
            res.EndDate = history.EndDate;
            res.StartDate = history.StartDate;
            _db.Entry<MembershipHistory>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Convert.ToBoolean(_db.SaveChanges());
        }
        public MembershipHistory GetHistoryById(string id)
        {
            return _db.History.Where(x => x.EnrollmentId == id).FirstOrDefault();
        }
    }
}
