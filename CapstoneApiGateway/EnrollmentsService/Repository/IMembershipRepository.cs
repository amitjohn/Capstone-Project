using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public interface IMembershipRepository
    {
        public bool UpdateMembershipPeriod(MembershipHistory history);
        public MembershipHistory GetHistoryById(string id);
    }
}
