using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobSeekerInfo
{
    // BBA, BSC, BA, etc
    public class DegreeInfo
    {
        public int Id { get; set; }        
        public string Name { get; set; }

        [ForeignKey("educationLevel")]
        public int educationLevelId { get; set; }
        
       //Navigation Properties
        public EducationLevel educationLevel { get; set; }
    }
}
