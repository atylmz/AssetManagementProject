using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAssetService
    {
        IResult AddAsset(Asset entity);
        IResult UpdateAsset(Asset entity);
        IResult DeleteAsset(int entity);
        IDataResult<Asset> GetAssetById(int id);
        IDataResult<List<Asset>> GetAllAssets();
    }
}
