using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Models.ApiModels
{
    public class ComboboxDTO
    {
        public List<BrandDTO> Brands { get; set; }
        public List<ModelDTO> Models { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }
        public List<TypeDTO> Types { get; set; }
        public List<GroupDTO> Groups { get; set; }
        public List<UnitDTO> Units { get; set; }
    }
}
