using JobPortalApp.Model.db_models.JobProviderAreas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("packages")]
        public int PackagesId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("user")]
        public Guid UserId { get; set; }             
        public  int JobPostId { get; set; }     
        public  int CvBuyInfoId { get; set; }
        public string TransactionId { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime Date { get; set; }


        // Navigation
        public User user { get; set; }
        public Packages  packages { get; set; }
       
    }
}
