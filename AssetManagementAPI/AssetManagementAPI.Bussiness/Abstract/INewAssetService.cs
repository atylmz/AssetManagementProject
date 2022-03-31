using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DtoModel.DTO.AssetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface INewAssetService
    {
        //Varlık ekle ekranından gelen verileri farklı tablolalara eklemek için oluşturuldu.

        IResult NewAssetAdd(NewAssetDTO dto);
    }
}
