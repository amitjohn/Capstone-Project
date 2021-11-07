using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Model
{
    public class UserProfile
    {
        [Key]
        public string EnrollmentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public Double Weight { get; set; }
        public int WaterIntake { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Calories { get; set; }
        [RegularExpression(@"^((Weight[\s]{1}Gain)|(Weight[\s]{1}Loss)|(Maintain))$")]
        public String Regime { get; set; }
        [ForeignKey("EnrollmentId")]
        public virtual Enrollment enrollment { get; set; }
    }
}
