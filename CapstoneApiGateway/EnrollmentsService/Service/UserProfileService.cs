using EnrollmentsService.Exceptions;
using EnrollmentsService.Model;
using EnrollmentsService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repo;
        private readonly IEnrollmentRepository _enrollRepo;
        public UserProfileService(IUserProfileRepository repo, IEnrollmentRepository enrollRepo)
        {
            _repo = repo;
            _enrollRepo = enrollRepo;
        }

        public bool AddUserProfile(UserProfile profile)
        {
            var res = _enrollRepo.GetUserById(profile.EnrollmentId);
            if (res == null)
                throw new EnrollmentNotFoundException($"{profile.EnrollmentId} does not Exist");
            return _repo.AddProfile(profile);
        }
        public List<int> CalculateNutrition(string EnrollmentId)
        {
            UserProfile profile = _repo.FindUserById(EnrollmentId);
            if (profile == null)
                throw new UserProfileNotFoundException($"{EnrollmentId} does not Exist");
            //Calculating Calories
            var Current = profile.Weight * 2.2 * 15;
            if (profile.Regime == Regime.Maintain)
                profile.Calories = (int)Current;
            else if (profile.Regime == Regime.WeightGain)
                profile.Calories = (int)(Current + (0.15 * profile.Calories));
            else if (profile.Regime == Regime.WeightLoss)
                profile.Calories = (int)(Current - (0.15 * profile.Calories));
            //Caculating Carbs
            profile.Carbs =(int) 0.30 * profile.Calories;
            //Calculating Protein
            profile.Protein = (int)0.40 * profile.Calories;
            UpdateProfile(EnrollmentId, profile);
            return new List<int>() {profile.Calories, profile.Carbs, profile.Protein };
        }

        public bool UpdateProfile(string EnrollmentId, UserProfile userProfile)
        {
            UserProfile profile = _repo.FindUserById(EnrollmentId);
            if (profile == null)
                throw new UserProfileNotFoundException($"{EnrollmentId} does not Exist");
            return _repo.UpdateProfile(EnrollmentId, userProfile);
        }

        public bool UpdateRegime(string EnrollmentId, string regimeName)
        {
            throw new NotImplementedException();
        }
    }
}
