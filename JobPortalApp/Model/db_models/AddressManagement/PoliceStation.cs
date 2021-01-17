using JobPortalApp.Model.db_models.AppUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AddressManagement
{
    public class PoliceStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }

        // Navigation Properties
        public District District { get; set; }
        public ICollection<JobProviderUser> CompanyInformation { get; set; }
        public ICollection<JobSeekerUser>  jobSeekers { get; set; }
        
    }
}
