using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class ViewResumeList
    {
        public int Id { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        [ForeignKey("JobSeekerUser")]
        public Guid JobSeekerUserId { get; set; }

        // Navigation 

        public Invoice Invoice { get; set; }
        public User JobSeekerUser { get; set; }
    }
}
