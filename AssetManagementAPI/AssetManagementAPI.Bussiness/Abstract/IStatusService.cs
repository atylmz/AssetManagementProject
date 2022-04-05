using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IStatusService 
    {
        IResult AddStatus(Status entity);
        IResult UpdateStatus(Status entity);
        IResult DeleteStatus(int entity);
        IDataResult<Status> GetStatusById(int id);
        IDataResult<List<Status>> GetAllStatuss();
    }
}
