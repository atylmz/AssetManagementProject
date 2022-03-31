using AssetManagementAPI.DataAccess.Repository.IRepository;
using AssetManagementAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Select
{
    public interface ISelectableRepository<T> : IRepository<T> where T : class, IEntity
    {
        T Get(Expression<Func<T, bool>> condition);
        T GetById(int Id);
        List<T> GetAll(Expression<Func<T, bool>> condition = null);
    }
}
