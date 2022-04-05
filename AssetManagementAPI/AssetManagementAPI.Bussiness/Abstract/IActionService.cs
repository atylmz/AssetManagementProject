
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IActionService
    {
        IResult AddAction(Action entity);
        IResult UpdateAction(Action entity);
        IResult DeleteAction(int entity);
        IDataResult<Action> GetActionById(int id);
        IDataResult<List<Action>> GetAllActions();
    }
}
