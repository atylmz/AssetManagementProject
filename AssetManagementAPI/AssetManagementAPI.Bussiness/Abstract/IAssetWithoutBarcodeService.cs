using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAssetWithoutBarcodeService
    {
        IResult AddAssetWithoutBarcode(AssetWithoutBarcode entity);
        IResult UpdateAssetWithoutBarcode(AssetWithoutBarcode entity);
        IResult DeleteAssetWithoutBarcode(int entity);
        IDataResult<AssetWithoutBarcode> GetAssetWithoutBarcodeById(int id);
        IDataResult<List<AssetWithoutBarcode>> GetAllAssetWithoutBarcodes();
    }
}
