
using AssetManagementAPI.DtoModel.DTO.CurrencyDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class CurrencyMapProfile : Profile,IMapProfile
    {
        public CurrencyMapProfile()
        {
            CreateMap<Currency, CurrencyListDTO>();
            CreateMap<CurrencyListDTO, Currency>();

            CreateMap<Currency, CurrencyAddDTO>();
            CreateMap<CurrencyAddDTO, Currency>();

            CreateMap<Currency, CurrencyUpdateDTO>();
            CreateMap<CurrencyUpdateDTO, Currency>();

            CreateMap<Currency, CurrencyDeleteDTO>();
            CreateMap<CurrencyDeleteDTO, Currency>();
        }
    }
}