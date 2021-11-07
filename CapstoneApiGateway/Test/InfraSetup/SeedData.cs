using EnrollmentsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.InfraSetup
{
    class SeedData
    {
        public static void PopulateTestData(DataContext context)
        {
            AddEnrollments(context);
            AddUserProfile(context);
            AddMembershipHistory(context);
        }

        private static void AddMembershipHistory(DataContext context)
        {
            context.History.Add(new MembershipHistory() { EnrollmentId="GOLD010", StartDate=new DateTime(2021-09-01).Date,EndDate=new DateTime(2022-01-01) });
        }

        private static void AddUserProfile(DataContext context)
        {
            context.Profiles.Add(new UserProfile() { EnrollmentId = "GOLD010", Name = "Shaw J", Age = 27, Height = 182, Weight = 72, WaterIntake = 8, Regime = Regime.Maintain });
        }

        private static void AddEnrollments(DataContext context)
        {
            context.Enrollments.Add(new Enrollment() { EnrollmentId = "GOLD010", Name = "Shaw J", ProgramName = "Standard", ProgramCost = 5999, Email = "shawj@gmail.com", ContactNo = "1111111111", MembershipStatus = false });
            context.Enrollments.Add(new Enrollment() { EnrollmentId = "GOLD011", Name = "Graham K", ProgramName = "Premium", ProgramCost = 10999, Email = "grahamk@gmail.com", ContactNo = "2222222222", MembershipStatus = true });

        }
    }
}
