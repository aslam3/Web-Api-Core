using JobPortalApp.Model.db_models.JobProviderAreas;
using JobPortalApp.Model.db_models.JobSeekerInfo;
using JobPortalApp.Model.db_models.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models
{
    public class BusinessCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public List<JobProviderUser> jobProviderUsers { get; set; }
        public List<CareerInformation> CareerInformation { get; set; }
        public List<JobPost> jobPosts { get; set; }
    }
}
