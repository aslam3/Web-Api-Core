using JobPortalApp.Model.db_models.AddressManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class CvBankQuery
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }              
        [ForeignKey("businessCategory")]
        public int BusinessCategoryId { get; set; } // Employer Desire Category        
        [ForeignKey("packages")]
        public int PackagesId { get; set; } // Selected Packages
        public DateTime Date { get; set; }

        // Navigation Properties
        public User user { get; set; }        
        public BusinessCategory businessCategory { get; set; }
        public Packages packages { get; set; }

    }
}
