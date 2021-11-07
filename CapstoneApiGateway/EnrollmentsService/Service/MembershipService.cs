using EnrollmentsService.Exceptions;
using EnrollmentsService.Model;
using EnrollmentsService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _repo;

        public MembershipService(IMembershipRepository repo)
        {
            _repo = repo;
        }

        public bool UpdateMembershipPeriod(MembershipHistory history)
        {
            if (_repo.GetHistoryById(history.EnrollmentId) == null)
                throw new EnrollmentNotFoundException();
            return _repo.UpdateMembershipPeriod(history);
        }
        public int ReturnRemainingDays(string id)
        {
            var res = _repo.GetHistoryById(id);
            if (res == null)
                throw new EnrollmentNotFoundException();
            return (int)(res.EndDate - DateTime.Now).TotalDays;
        }
        public MembershipHistory GetHistoryById(string id)
        {
            if (_repo.GetHistoryById(id) == null)
                throw new EnrollmentNotFoundException();
            return _repo.GetHistoryById(id);
        }
    }
}
