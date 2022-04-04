using AssetManagementAPI.DataAccess.Abstract;
using AssetManagementAPI.Entity;
using AssetManagementAPI.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AssetManagementContext _context;
        public AuthRepository(AssetManagementContext context)
        {
            _context = context;
        }

        public async Task<Personnel> Login(string username, string password)
        {
            var user = await _context.Personnel.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            if (!Check(password, user.PasswordSalt, user.PasswordHash))
            {
                return null;
            }
            return user;
        }
        private bool Check(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < password.Length; i++)
                {
                    if (passwordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<Personnel> Register(Personnel user, string password)
        {
            byte[] passHash, passSalt;
            PersonnelSave(password, out passHash, out passSalt);
            user.PasswordSalt = passSalt;
            user.PasswordHash = passHash;
            await _context.Personnel.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void PersonnelSave(string password, out byte[] passHash, out byte[] passSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            if(!await _context.Personnel.AnyAsync(a => a.Username == username))
            {
                return false;
            }
            return false;
        }
    }
}
