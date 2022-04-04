using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAuthService
    {
        Task<Personnel> Login(string password, string username);
        Task<Personnel> Register(Personnel user, string password);
        Task<bool> UserExist(string username);
    }
}
