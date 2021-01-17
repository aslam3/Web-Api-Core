using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobSeekerInfo
{
    public class AcademicInformation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        public string MajorSub { get; set; }
        public string InstituteName { get; set; }
        [ForeignKey("resultType")]
        public int ResultTypeId { get; set; }
        public int MarkScale { get; set; }
        public decimal ObtainMark { get; set; }
        public string PassingYear { get; set; }
        public string Duration { get; set; }

        // Navigation Properties
        public User user { get; set; }
        public DegreeInfo Degree { get; set; }
        public ResultType  resultType { get; set; }
    }
}
