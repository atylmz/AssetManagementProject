using AssetManagementAPI.DtoModel.DTO.UnitDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class UnitMapProfile : Profile ,IMapProfile
    {
        public UnitMapProfile()
        {
            CreateMap<Unit, UnitListDTO>();
            CreateMap<UnitListDTO, Unit>();

            CreateMap<Unit, UnitAddDTO>();
            CreateMap<UnitAddDTO, Unit>();

            CreateMap<Unit, UnitUpdateDTO>();
            CreateMap<UnitUpdateDTO, Unit>();

            CreateMap<Unit, UnitDeleteDTO>();
            CreateMap<UnitDeleteDTO, Unit>();
        }
    }
}
