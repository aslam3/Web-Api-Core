using JobPortalApp.Model;
using JobPortalApp.Model.db_models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.ViewModel
{
    public class UserVM
    {    
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
       
    }
}
