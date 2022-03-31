using AssetManagementAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class, IEntity
    {
        int SaveChanges();
    }
}
