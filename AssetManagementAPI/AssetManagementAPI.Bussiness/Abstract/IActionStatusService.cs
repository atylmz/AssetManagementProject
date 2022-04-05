using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IActionStatusService
    {
        IResult AddActionStatus(ActionStatus entity);
        IResult UpdateActionStatus(ActionStatus entity);
        IResult DeleteActionStatus(int entity);
        IDataResult<ActionStatus> GetActionStatusById(int id);
        IDataResult<List<ActionStatus>> GetAllActionStatuss();
    }
}
