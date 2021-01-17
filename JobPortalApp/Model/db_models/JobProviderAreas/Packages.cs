using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.JobProviderAreas
{
    public class Packages
    {   
       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string  Description { get; set; }
        public int MaxValue { get; set; }       
        public PackageTypes PackageType { get; set; }
        // Navigation Properties
        public  List<Invoice> invoices { get; set; }
    }

    public enum PackageTypes
    {
        CircularPost, Resume
    }
}
