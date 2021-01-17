using JobPortalApp.Model.db_models.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AddressManagement
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }

        // Navigation Properties
        public ICollection<JobProviderUser> CompanyInformation { get; set; }
        public ICollection<PoliceStation> PoliceStations { get; set; }
    }
}
