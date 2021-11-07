using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnrollmentsService.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
                   .Property(t => t.EnrollmentId)
                   .HasValueGenerator<IdValueGenerator>();
        }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<MembershipHistory> History { get; set; }
    }
    public class IdValueGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            var context = (DataContext)entry.Context;
            var id = context.Enrollments.LastOrDefault()?.EnrollmentId == " "?
                    "GOLD0001"
                    : Regex.Replace(context.Enrollments.LastOrDefault()?.EnrollmentId, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));

            return id;
        }
    }
}
