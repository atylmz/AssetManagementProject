using AssetManagementAPI.DataAccess.Repository.IRepository;
using AssetManagementAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Update
{
    public interface IUpdatableRepository<T> : IRepository<T> where T : class, IEntity
    {
        void Update(T entity);
    }
}
