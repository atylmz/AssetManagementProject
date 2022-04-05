using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.DTO.AssetOwnerDTO
{
    public class AssetOwnerDTO
    {
        public int AssetId { get; set; }
        public int OwnerTypeId { get; set; }
        public int? PersonnelId { get; set; }
        public int? TeamId { get; set; }
        public DateTime Date { get; set; }
    }
}
