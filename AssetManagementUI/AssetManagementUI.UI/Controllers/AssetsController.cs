using AssetManagementUI.UI.Models.ApiModels;
using AssetManagementUI.UI.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using AssetManagementUI.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagementUI.UI.Controllers
{
    [Authorize(Roles = "User")]
    public class AssetsController : Controller
    {
        private readonly ComboboxFillerProvider _pro;
        private readonly AssetProvider _asset;
        private readonly IDistributedCache _cache;

        public AssetsController(ComboboxFillerProvider pro, AssetProvider asset, IDistributedCache cache)
        {
            _pro = pro;
            _asset = asset;
            _cache = cache;
        }

        public async Task<IActionResult> Add()
        {
            ComboboxDTO data;
            data = await _pro.GetComboboxFiller();
            //string key = "combobox_" + DateTime.Now.ToString("yyyyMMdd");
            //data = await _cache.GetRecordAsync<ComboboxDTO>(key);
            //if(data == null)
            //{
            //    data = await _pro.GetComboboxFiller();
            //    await _cache.SetRecordAsync<ComboboxDTO>(key, data);
            //} 
            ViewBag.brand = data.Brands;
            ViewBag.model = data.Models;
            ViewBag.currency = data.Currencies;
            ViewBag.type = data.Types;
            ViewBag.group = data.Groups;
            ViewBag.unit = data.Units;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AssetFullDTO dto)
        {
            string token = HttpContext.Session.MySessionGet<string>("token");
            if (token is null)
            {
                return RedirectToAction("Login", "Index");
            }
            else
            {
                dto.Date = DateTime.Now;
                dto.CompanyId = 1;
                dto.CreatedDate = DateTime.Now;
                dto.ModifiedDate = DateTime.Now;
                string value = await _asset.AddAsset(dto, token);

                return Redirect("Add");
            }
          
           
        }
        [HttpPost]
        public async Task<JsonResult> GetModel([FromQuery]int id)
        {
            List<ModelDTO> model = new List<ModelDTO>();
            var data = await _pro.GetComboboxFiller();
            foreach (var item in data.Models)
            {
                if (item.BrandId == id)
                {
                    model.Add(item);
                }
            }
            return Json(model);
        }
    }
}
