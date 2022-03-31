using AssetManagementAPI.DtoModel.DTO.ModelDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class ModelMapProfile : Profile, IMapProfile
    {
        public ModelMapProfile()
        {

            CreateMap<Model, ModelListDTO>();
            CreateMap<ModelListDTO, Model>();

            CreateMap<Model, ModelAddDTO>();
            CreateMap<ModelAddDTO, Model>();

            CreateMap<Model, ModelUpdateDTO>();
            CreateMap<ModelUpdateDTO, Model>();

            CreateMap<Model, ModelDeleteDTO>();
            CreateMap<ModelDeleteDTO, Model>();
        }
    }
}
