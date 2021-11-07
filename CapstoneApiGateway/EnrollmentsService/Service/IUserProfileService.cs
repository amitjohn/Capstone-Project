using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public interface IUserProfileService
    {
        bool AddUserProfile(UserProfile profile);
        List<int> CalculateNutrition(string EnrollmentId);
        bool UpdateProfile(string EnrollmentId, UserProfile profile);
        bool UpdateRegime(string EnrollmentId, string regimeName);

    }
}
