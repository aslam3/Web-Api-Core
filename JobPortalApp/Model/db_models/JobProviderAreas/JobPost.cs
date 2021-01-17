using JobPortalApp.Model.db_models.JobSeekerInfo;
using JobPortalApp.Model.db_models.AppUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class JobPost
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public string JobTitle { get; set; }
        public string Designation { get; set; }
        public int NoOfVacancies { get; set; }
        public DateTime CircularStartDate { get; set; }
        public DateTime CircularExpiredDate { get; set; }
        [ForeignKey("businessCategory")]
        public int BusinessCategoryId { get; set; }
        public string JobResponsibilities { get; set; }
        public string JobLocation { get; set; }
        public string Salary { get; set; }
        public string AdditionalInformation { get; set; }
        public string Otherbenefits { get; set; }
        [ForeignKey("educationLevel")]
        public int MinimumEducationLevelId { get; set; }
        public string Experience { get; set; }
        public Gender gender { get; set; }
        public int MaxAge { get; set; }

        [ForeignKey("packages")]
        public int PackageId { get; set; }
        public JobPostStatus  PostStatus { get; set; }


        // Navigation Properties
        public Packages  packages { get; set; }
        public BusinessCategory businessCategory { get; set; }
        public EmploymentStatus  EmploymentStatus { get; set; }
        public  EducationLevel educationLevel { get; set; }
        public User user { get; set; }
        public IList<PostModerator> postModerators { get; set; }


    }

    public enum JobPostStatus
    {
        Draft, Published
    }
    public enum EmploymentStatus{
        Contractual, Permanent
    }
}
