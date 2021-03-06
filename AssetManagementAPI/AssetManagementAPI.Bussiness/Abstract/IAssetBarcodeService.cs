using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IAssetBarcodeService
    {
        IResult AddAssetBarcode(AssetBarcode entity);
        IResult UpdateAssetBarcode(AssetBarcode entity);
        IResult DeleteAssetBarcode(int entity);
        IDataResult<AssetBarcode> GetAssetBarcodeById(int id);
        IDataResult<List<AssetBarcode>> GetAllAssetBarcodes();
    }
}
