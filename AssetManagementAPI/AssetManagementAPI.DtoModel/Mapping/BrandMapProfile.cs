using AssetManagementAPI.DtoModel.DTO.BrandDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class BrandMapProfile : Profile,IMapProfile
    {
        public BrandMapProfile()
        {
            CreateMap<Brand, BrandListDTO>();
            CreateMap<BrandListDTO, Brand>();

            CreateMap<Brand, BrandAddDTO>();
            CreateMap<BrandAddDTO, Brand>();

            CreateMap<Brand, BrandUpdateDTO>();
            CreateMap<BrandUpdateDTO, Brand>();

            CreateMap<Brand, BrandDeleteDTO>();
            CreateMap<BrandDeleteDTO, Brand>();
        }
    }
}
