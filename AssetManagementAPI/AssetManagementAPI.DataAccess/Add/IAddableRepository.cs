using AssetManagementAPI.DataAccess.Repository.IRepository;
using AssetManagementAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Add
{
    public interface IAddableRepository<T> : IRepository<T> where T : class,IEntity
    {
        void Add(T entity);
    }
}
