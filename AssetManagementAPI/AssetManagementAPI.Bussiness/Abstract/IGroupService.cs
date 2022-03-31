using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IGroupService
    {
        IResult AddGroup(Group entity);
        IResult UpdateGroup(Group entity);
        IResult DeleteGroup(int entity);
        IDataResult<Group> GetGroupById(int id);
        IDataResult<List<Group>> GetAllGroups();
    }
}
