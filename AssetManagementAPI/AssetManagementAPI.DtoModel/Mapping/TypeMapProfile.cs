using AssetManagementAPI.DtoModel.DTO.TypeDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class TypeMapProfile : Profile , IMapProfile
    {
        public TypeMapProfile()
        {
            CreateMap<Type, TypeListDTO>();
            CreateMap<TypeListDTO, Type>();

            CreateMap<Type, TypeAddDTO>();
            CreateMap<TypeAddDTO, Type>();

            CreateMap<Type, TypeUpdateDTO>();
            CreateMap<TypeUpdateDTO, Type>();

            CreateMap<Type, TypeDeleteDTO>();
            CreateMap<TypeDeleteDTO, Type>();
        }
    }
}
