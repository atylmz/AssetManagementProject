using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IUnitService
    {
        IResult AddUnit(Unit entity);
        IResult UpdateUnit(Unit entity);
        IResult DeleteUnit(int entity);
        IDataResult<Unit> GetUniteById(int id);
        IDataResult<List<Unit>> GetAllUnits();
    }
}
