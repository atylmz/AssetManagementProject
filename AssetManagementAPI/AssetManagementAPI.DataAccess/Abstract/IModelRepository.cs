using AssetManagementAPI.DataAccess.Add;
using AssetManagementAPI.DataAccess.Delete;
using AssetManagementAPI.DataAccess.Select;
using AssetManagementAPI.DataAccess.Update;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Abstract
{
    public interface IModelRepository : IAddableRepository<Model>, IUpdatableRepository<Model>,
        IDeletableRepository<Model>, ISelectableRepository<Model>
    {
    }
}
