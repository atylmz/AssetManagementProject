using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DtoModel.DTO.BrandDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using AssetManagementAPI.DtoModel.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementAPI.DataAccess.Repository.Repository;

namespace AssetManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly  IBrandService _service;
        private readonly IMapper _mapper;
        private readonly IAssetService _asset;
        

        public DenemeController(IMapper mapper, IBrandService service, IAssetService asset)
        {
            _mapper = mapper;
            _service = service;
            _asset = asset;
        
        }
        [HttpGet]

        public IActionResult Get()
        {
            var result = _service.GetAllBrands().Data;
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody]BrandAddDTO dto)
        {
           
            _service.AddBrand(_mapper.Map<Brand>(dto));
            return Ok();
        }
        [HttpGet("asset")]
        public IActionResult GetAsset()
        {
            return Ok(_asset.GetAllAssets().Data);
        }
    }
}
