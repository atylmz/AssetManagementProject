using AssetManagementUI.UI.Models.ApiModels;
using AssetManagementUI.UI.Provider;
using Microsoft.AspNetCore.Mvc;
using AssetManagementUI.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Controllers
{
    public class LoginController : Controller
    {
        AuthProvider _auth;

        public LoginController(AuthProvider auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            string token = HttpContext.Session.MySessionGet<string>("token");
            PersonnelWithTokenDTO user = new PersonnelWithTokenDTO();
            if (token == null)
            {
                user = await _auth.Login(dto.Username, dto.Password);
                HttpContext.Session.MySessionSet("token", user.Token);
                HttpContext.Session.MySessionSet("user", user);
                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }
    }
}
