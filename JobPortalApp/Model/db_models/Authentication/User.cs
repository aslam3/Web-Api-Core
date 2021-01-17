using JobPortalApp.Model.db_models.AppUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models
{
    public class User:IdentityUser<Guid>
    {
        public string Picture { get; set; }        
    }
}
