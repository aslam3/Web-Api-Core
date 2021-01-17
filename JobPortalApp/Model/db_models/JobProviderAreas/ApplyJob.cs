using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class ApplyJob
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        [ForeignKey("jobPost")]
        public int JobCircularId { get; set; }
        public decimal ExpectedSalary { get; set; }
        public DateTime AppliedDate { get; set; }

        // Navigation Properties
        public User user { get; set; }
        public JobPost jobPost { get; set; }

    }
}
