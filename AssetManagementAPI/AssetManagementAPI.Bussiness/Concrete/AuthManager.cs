using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUnitOfWork _uow;

        public AuthManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Personnel> Login(string password, string username)
        {
             return await _uow.Auth.Login(username, password);
        }

        public async Task<Personnel> Register(Personnel user, string password)
        {
            return await _uow.Auth.Register(user, password); 
        }
        public async Task<bool> UserExist(string username)
        {
            return await _uow.Auth.UserExist(username);
        }
    }
}
