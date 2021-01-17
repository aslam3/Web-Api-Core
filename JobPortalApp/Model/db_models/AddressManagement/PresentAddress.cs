using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AddressManagement
{
    public class PresentAddress
    {
        public int Id { get; set; }
        [ForeignKey("registration")]
        public int UserId { get; set; }
        public string PresentAddress_HouseRoadVillage { get; set; }
        
        [ForeignKey("policeStation")]
        public int PresentAddress_PoliceStationId { get; set; }

        //Navigation Properties

        public PoliceStation policeStation { get; set; }
        public Registration registration { get; set; }
        
    }
}
