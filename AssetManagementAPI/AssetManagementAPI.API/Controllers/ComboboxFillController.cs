using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.DtoModel.DTO.BrandDTO;
using AssetManagementAPI.DtoModel.DTO.ComboboxDTO;
using AssetManagementAPI.DtoModel.DTO.CurrencyDTO;
using AssetManagementAPI.DtoModel.DTO.GroupDTO;
using AssetManagementAPI.DtoModel.DTO.ModelDTO;
using AssetManagementAPI.DtoModel.DTO.TypeDTO;
using AssetManagementAPI.DtoModel.DTO.UnitDTO;
using AutoMapper;
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
    //[Authorize]
    public class ComboboxFillController : ControllerBase
    {
        private readonly IBrandService _brand;
        private readonly IModelService _model;
        private readonly ITypeService _type;
        private readonly IGroupService _group;
        private readonly ICurrencyService _currency;
        private readonly IMapper _mapper;
        private readonly IUnitService _unit;
        public ComboboxFillController(IBrandService brand, ITypeService type, IGroupService group, ICurrencyService currency, IMapper mapper, IModelService model, IUnitService unitService)
        {
            _brand = brand;
            _type = type;
            _group = group;
            _currency = currency;
            _mapper = mapper;
            _model = model;
            _unit = unitService;
        }
        [HttpGet("comboboxfiller")]
        public IActionResult ComboboxFiller()
        {

            var brand = _brand.GetAllBrands();
            var model = _model.GetAllModels();
            var group = _group.GetAllGroups();
            var type = _type.GetAllTypes();
            var currency = _currency.GetAllCurrencies();
            var unit = _unit.GetAllUnits();
            

            if (brand.Success == true && model.Success == true && group.Success == true && type.Success == true && currency.Success == true && unit.Success == true)
            {
                List<BrandListDTO> brands = _mapper.Map<List<BrandListDTO>>(brand.Data);
                List<ModelListDTO> models = _mapper.Map<List<ModelListDTO>>(model.Data);
                List<GroupListDTO> groups = _mapper.Map<List<GroupListDTO>>(group.Data);
                List<TypeListDTO> types = _mapper.Map<List<TypeListDTO>>(type.Data);
                List<UnitListDTO> units = _mapper.Map<List<UnitListDTO>>(unit.Data);
                List<CurrencyListDTO> currencies = _mapper.Map<List<CurrencyListDTO>>(currency.Data);
                AssetComboboxDTO dto = new AssetComboboxDTO()
                {
                    Brands = brands,
                    Models = models,
                    Currencies = currencies,
                    Groups = groups,
                    Types = types,
                    Units = units
                };
                return Ok(dto);
            }

            return BadRequest(brand.exception);
        }
    }
}
