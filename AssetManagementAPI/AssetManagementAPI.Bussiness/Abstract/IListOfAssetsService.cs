using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DtoModel.DTO.AssetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IListOfAssetsService
    {
        IDataResult<List<AllAssetListDTO>> AllAssetList();
    }
}
