using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DtoModel.DTO.AssetOwnerDTO;
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
    public class ActionController : ControllerBase
    {
        private readonly IAssetOwnerService _service;

        public ActionController(IAssetOwnerService service)
        {
            _service = service;
        }
        [HttpPost("owneradd")]
        public IActionResult OwnerAdd([FromBody]AssetOwnerDTO dto)
        {
            var result = _service.AssetOwnerAdder(dto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
