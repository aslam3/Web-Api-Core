using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AppUser
{
    public class AdminUser
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime Date { get; set; }

        // Navigation 
        public User user { get; set; }
    }
}
