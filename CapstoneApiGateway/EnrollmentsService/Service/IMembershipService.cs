using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public interface IMembershipService
    {
        public bool UpdateMembershipPeriod(MembershipHistory history);
        public MembershipHistory GetHistoryById(string id);
    }
}
