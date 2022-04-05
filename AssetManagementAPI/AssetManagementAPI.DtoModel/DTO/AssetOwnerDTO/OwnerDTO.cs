using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.DTO.AssetOwnerDTO
{
    public class OwnerDTO
    {
        public int OwnerId { get; set; }
        public int TeamId{ get; set; }
        public int PersonnelId { get; set; }
    }
}
