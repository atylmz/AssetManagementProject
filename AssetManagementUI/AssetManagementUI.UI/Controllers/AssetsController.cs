using AssetManagementUI.UI.Models.ApiModels;
using AssetManagementUI.UI.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Controllers
{
    public class AssetsController : Controller
    {
        private readonly ComboboxFillerProvider _pro;
        private readonly AssetProvider _asset;

        public AssetsController(ComboboxFillerProvider pro, AssetProvider asset)
        {
            _pro = pro;
            _asset = asset;
        }

        public async Task<IActionResult> Add()
        {
            ComboboxDTO data = await _pro.GetComboboxFiller();
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
            dto.Date = DateTime.Now;
            dto.CompanyId = 1;
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedDate = DateTime.Now;
            string value = await _asset.AddAsset(dto);
           
            return Redirect("Add");
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
