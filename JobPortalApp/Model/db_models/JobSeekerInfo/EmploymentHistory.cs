using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobSeekerInfo
{
    public class EmploymentHistory
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        [ForeignKey("businessCategoryId")]
        public int businessCategoryId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Responsibilities { get; set; }
        public string CompanyAddress { get; set; }
        [DataType(DataType.Date)]
        public DateTime JobstartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime JobEndDate { get; set; }

        public User user { get; set; }
        public BusinessCategory businessCategory { get; set; }
    }
}
