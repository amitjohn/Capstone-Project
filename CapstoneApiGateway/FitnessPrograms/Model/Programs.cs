using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPrograms.Model
{
    public class Programs
    {
        [BsonId]
        public int ProgramId { get; set; }
        [RegularExpression(@"^((Basic)|(Premium)|(Standard))$")]
        public string ProgramName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
