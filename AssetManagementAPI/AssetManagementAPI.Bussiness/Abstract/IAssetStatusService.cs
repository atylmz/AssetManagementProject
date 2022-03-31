using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAssetStatusService
    {
        IResult AddAssetStatus(AssetStatus entity);
        IResult UpdateAssetStatus(AssetStatus entity);
        IResult DeleteAssetStatus(int entity);
        IDataResult<AssetStatus> GetAssetStatusById(int id);
        IDataResult<List<AssetStatus>> GetAllAssetStatuss();
    }
}
