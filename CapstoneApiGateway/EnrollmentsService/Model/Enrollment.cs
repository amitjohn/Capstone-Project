using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnrollmentsService.Model
{
    public class Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EnrollmentId { get; set; }
        [RegularExpression(@"^((Basic)|(Premium)|(Standard))$")]
        public string ProgramName { get; set; }
        public int ProgramCost { get; set; }
        public bool MembershipStatus { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}
