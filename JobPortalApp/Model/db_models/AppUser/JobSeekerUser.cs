using JobPortalApp.Model.db_models.AddressManagement;
using JobPortalApp.Model.db_models.JobProviderAreas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AppUser
{
    public class JobSeekerUser
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public MaritialStatus MaritalStatus { get; set; }
        public Country Nationality { get; set; }
        public string NidNo { get; set; }
        public string MobileNo { get; set; }
        public string ResumeFile { get; set; }
        
        //  Address
        public string PresentAddress { get; set; }
        [ForeignKey("policeStation")]
        public int present_PoliceStationId { get; set; }
        public string PermanentAddress { get; set; }
        public int permanent_PoliceStationId { get; set; }



        // Navigation Properties
        public User user { get; set; }
        public PoliceStation policeStation { get; set; }
        public List<ApplyJob> applyJobs { get; set; }
    }

    public enum Gender
    {
        Male, Female, Both
    }
    public enum Religion
    {
        Islam, Hinduism, Buddhism, Christianity
    }
    public enum MaritialStatus
    {
        Single, Married
    }
    public enum Country
    {
        Bangladesh
    }
}
