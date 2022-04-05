using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DtoModel.DTO.AssetOwnerDTO;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAssetOwnerService
    {
        IResult AddAssetOwner(AssetOwner entity);
        IResult UpdateAssetOwner(AssetOwner entity);
        IResult DeleteAssetOwner(int entity);
        IDataResult<AssetOwner> GetAssetOwnerById(int id);
        IDataResult<List<AssetOwner>> GetAllAssetOwners();
        public IResult AssetOwnerAdder(AssetOwnerDTO dto);
    }
}
