using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface ICurrencyService
    {
        IResult AddCurrency(Currency entity);
        IResult UpdateCurrency(Currency entity);
        IResult DeleteCurrency(int entity);
        IDataResult<Currency> GetCurrencyById(int id);
        IDataResult<List<Currency>> GetAllCurrencies();
    }
}
