using JobPortalApp.Model.db_models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models
{
    public class Report
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid ReportedUserId { get; set; }
        public int JobPostId { get; set; }
        public DateTime Date { get; set; }

        // Navigation 
        public User user { get; set; }
    }
}
