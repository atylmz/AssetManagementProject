using AssetManagementAPI.Entity;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        Task<Personnel> Register(Personnel user, string password);
        Task<Personnel> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
