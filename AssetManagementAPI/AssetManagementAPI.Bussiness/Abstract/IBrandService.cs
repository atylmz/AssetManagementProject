using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IBrandService
    {
        IResult AddBrand(Brand entity);
        IResult UpdateBrand(Brand entity);
        IResult DeleteBrand(int entity);
        IDataResult<Brand> GetBrandById(int id);
        IDataResult<List<Brand>> GetAllBrands();
    }
}
