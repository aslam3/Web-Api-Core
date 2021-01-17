using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.ViewModel
{
    public class jwt_vm
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
