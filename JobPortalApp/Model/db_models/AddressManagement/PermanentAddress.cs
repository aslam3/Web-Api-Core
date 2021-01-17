using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApp.Model.db_models.AddressManagement
{
    public class PermanentAddress
    {
        public int Id { get; set; }
        [ForeignKey("registration")]
        public int UserId { get; set; }

        public string PermanentAddress_HouseRoadVillage { get; set; }

        [ForeignKey("policeStation")]
        public int PermanentAddress_PoliceStationId { get; set; }

        //Navigation Properties

        public PoliceStation policeStation { get; set; }
        public Registration registration { get; set; }
    }
}
