using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DtoModel.DTO.AuthDTO;
using AssetManagementAPI.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IConfiguration _conf;

        public AuthController(IConfiguration conf, IAuthService auth)
        {
            _conf = conf;
            _auth = auth;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (await _auth.UserExist(dto.Username))
            {
                ModelState.AddModelError("user exist", "User Already Exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new Personnel()
            {
                Username = dto.Username,
                CompanyId = dto.CompanyId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
                ModifiedBy = dto.ModifiedBy,
                ModifiedDate = dto.ModifiedDate,
            };

            await _auth.Register(user, dto.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _auth.Login(dto.Password, dto.Username);
            if (user == null)
            {
                return null;
            }
            else
            {
                var key = Encoding.ASCII.GetBytes(_conf.GetSection("Appsettings:Token").Value);

                var description = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Subject = new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                    {
                        new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.PersonnelId.ToString()),
                        new System.Security.Claims.Claim(ClaimTypes.Name, user.Username),

                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(description);
                var value = tokenHandler.WriteToken(token);

                return Ok(new LoginWithUserDTO()
                {
                    Token = value,
                    CompanyId = user.CompanyId,
                    PersonnelId = user.PersonnelId,
                });
            }
        }


    }
}
