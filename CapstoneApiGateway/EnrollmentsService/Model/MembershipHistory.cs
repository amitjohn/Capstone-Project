using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Model
{
    public class MembershipHistory
    {
        [Key]
        public string EnrollmentId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        [ForeignKey("EnrollmentId")]
        public virtual Enrollment enrollment { get; set; }
    }
}
