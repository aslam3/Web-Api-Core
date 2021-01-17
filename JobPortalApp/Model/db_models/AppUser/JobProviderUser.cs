using JobPortalApp.Model.db_models.AddressManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AppUser
{
    public class JobProviderUser
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
  
        [ForeignKey("PoliceStation")]
        public int PoliceStationId { get; set; }
 
        [ForeignKey("BusinessCategory")]
        public int BusinessCategoryId { get; set; }
        public string BusinessDescription { get; set; }
        public string TradeLicenseNo { get; set; }
        public string WebsiteUrl { get; set; }
        public string CompanyLogo { get; set; } 
        public string ContactPersonName { get; set; }
        public string ContactPersonPhoneNo { get; set; }
        public string ContactPersonEmail { get; set; }

        // Navigation Properties
        public User user { get; set; }
        public PoliceStation PoliceStation { get; set; }        
        public BusinessCategory BusinessCategory { get; set; }
    }
}
