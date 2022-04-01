using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.DTO.AssetDTO
{
    public class AllAssetListDTO
    {
        public string Barcode { get; set; }
        public string AssetType { get; set; }
        public decimal? Price { get; set; }
        public string Brand { get; set; }
        public string Model{ get; set; }
    }
}
