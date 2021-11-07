using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DataContext _db;

        public UserProfileRepository(DataContext db)
        {
            _db = db;
        }

        public bool AddProfile(UserProfile profile)
        {
            //When a userProfile is created, membership status willa automatically update to true.
            var res = _db.Enrollments.Where(x => x.EnrollmentId.Equals(profile.EnrollmentId)).FirstOrDefault();
            res.MembershipStatus = true;
            _db.Entry<Enrollment>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Profiles.Add(profile);
            return Convert.ToBoolean(_db.SaveChanges());
        }

        public UserProfile FindUserById(string EnrollmentId)
        {
            return _db.Profiles.Where(x => x.Equals(EnrollmentId)).FirstOrDefault();
        }

        public bool UpdateProfile(string EnrollmentId, UserProfile profile)
        {
            var res = _db.Profiles.Where(x=>x.EnrollmentId.Equals(EnrollmentId)).FirstOrDefault();
            res.Age = profile.Age;
            res.Weight = profile.Weight;
            res.Height = profile.Height;
            res.WaterIntake = profile.WaterIntake;
            res.Protein = profile.Protein;
            res.Calories = profile.Calories;
            res.Carbs = profile.Carbs;
            res.Regime = profile.Regime;
            _db.Entry<UserProfile>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Convert.ToBoolean(_db.SaveChanges());
        }

        public bool UpdateRegime(string EnrollmentId, string regimeName)
        {
            throw new NotImplementedException();
        }
    }
}
