using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class InterviewInvitation
    {
        public int Id { get; set; }
        [ForeignKey("applyJob")]
        public int AppliedJobId { get; set; }
        public string MassageSubject { get; set; }
        public string InvitationMassage { get; set; }
        public DateTime InvitationDate { get; set; }

        // Navigation Properties
        public ApplyJob applyJob { get; set; }
    }
}
