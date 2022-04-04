using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Models.ApiModels
{
    public class PersonnelWithTokenDTO
    {
        public string Token { get; set; }
        public int PersonnelId { get; set; }
        public int? CompanyId { get; set; }
        public int? RoleId { get; set; }
        public int? ClaimId { get; set; }
    }
}
