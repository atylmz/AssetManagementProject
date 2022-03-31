using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface IModelService
    {
        IResult AddModel(Model entity);
        IResult UpdateModel(Model entity);
        IResult DeleteModel(int entity);
        IDataResult<Model> GetModelById(int id);
        IDataResult<List<Model>> GetAllModels();
    }
}
