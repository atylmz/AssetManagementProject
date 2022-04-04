using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.DTO.AuthDTO
{
    public class LoginWithUserDTO
    {
        public string Token { get; set; }
        public int PersonnelId { get; set; }
        public int? CompanyId { get; set; }
        public int? RoleId { get; set; }
        public int? ClaimId { get; set; }
    }
}
