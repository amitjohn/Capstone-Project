using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public interface IUserProfileRepository
    {
        bool AddProfile(UserProfile profile);
        UserProfile FindUserById(string EnrollmentId);
        bool UpdateProfile(string EnrollmentId, UserProfile profile);
        bool UpdateRegime(string EnrollmentId, string regimeName);
    }
}
