using AssetManagementAPI.DtoModel.DTO.GroupDTO;
using AssetManagementAPI.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DtoModel.Mapping
{
    public class GroupMapProfile : Profile, IMapProfile
    {
        public GroupMapProfile()
        {
            CreateMap<Group, GroupListDTO>();
            CreateMap<GroupListDTO, Group>();

            CreateMap<Group, GroupAddDTO>();
            CreateMap<GroupAddDTO, Group>();

            CreateMap<Group, GroupUpdateDTO>();
            CreateMap<GroupUpdateDTO, Group>();

            CreateMap<Group, GroupDeleteDTO>();
            CreateMap<GroupDeleteDTO, Group>();
        }
    }
}
