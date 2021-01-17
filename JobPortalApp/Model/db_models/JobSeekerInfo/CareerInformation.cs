using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobSeekerInfo
{
    public class CareerInformation
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public string CareerSummary { get; set; }
        public string CareerObjective { get; set; }
        public float PresentSalary { get; set; }
        public float ExpectedSalary { get; set; }
        // Interested Business Industry
        [ForeignKey("businessCategory")]
        public int businessCategoryId { get; set; }
        
        // Navigation Properties
        public User user { get; set; }
        public BusinessCategory  businessCategory { get; set; }
    }
}
