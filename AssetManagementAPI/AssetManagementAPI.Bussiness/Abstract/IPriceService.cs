using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IPriceService
    {
        IResult AddPrice(Price entity);
        IResult UpdatePrice(Price entity);
        IResult DeletePrice(int entity);
        IDataResult<Price> GetPriceById(int id);
        IDataResult<List<Price>> GetAllPrices();
    }
}
