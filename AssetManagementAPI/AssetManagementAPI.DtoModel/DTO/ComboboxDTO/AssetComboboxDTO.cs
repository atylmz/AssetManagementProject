using AssetManagementAPI.DtoModel.DTO.BrandDTO;
using AssetManagementAPI.DtoModel.DTO.CurrencyDTO;
using AssetManagementAPI.DtoModel.DTO.GroupDTO;
using AssetManagementAPI.DtoModel.DTO.ModelDTO;
using AssetManagementAPI.DtoModel.DTO.TypeDTO;
using AssetManagementAPI.DtoModel.DTO.UnitDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.DTO.ComboboxDTO
{
    public class AssetComboboxDTO
    {
        public List<BrandListDTO> Brands { get; set; }
        public List<ModelListDTO> Models { get; set; }
        public List<CurrencyListDTO> Currencies { get; set; }
        public List<TypeListDTO> Types { get; set; }
        public List<GroupListDTO> Groups { get; set; }
        public List<UnitListDTO> Units { get; set; }
    }
}
