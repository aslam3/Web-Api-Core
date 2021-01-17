using JobPortalApp.Model.db_models.JobProviderAreas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models
{
    public class PostModerator
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("jobPost")]
        public int jobPostId { get; set; }

        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public PostStatus Status { get; set; }
        public DateTime Date { get; set; }

        // Navigation Properties
        public JobPost jobPost { get; set; }
        public User user { get; set; }
    }

    public enum PostStatus{ Active, Deactivate, Unpaid, Spam}
}
