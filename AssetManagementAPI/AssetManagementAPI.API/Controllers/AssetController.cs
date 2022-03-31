using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DtoModel.DTO.AssetDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly INewAssetService _asset;

        public AssetController(INewAssetService asset)
        {
            _asset = asset;
        }

        [HttpPost("addasset")]
        public IActionResult AddAsset([FromBody]NewAssetDTO dto)
        {
            var result =_asset.NewAssetAdd(dto);
            if(result.Success == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
