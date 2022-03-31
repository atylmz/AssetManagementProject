using AssetManagementAPI.Core.Result;
using AssetManagementAPI.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Abstract
{
    public interface ITypeService
    {
        IResult AddType(Type entity);
        IResult UpdateType(Type entity);
        IResult DeleteType(int entity);
        IDataResult<Type> GetTypeById(int id);
        IDataResult<List<Type>> GetAllTypes();
    }
}
