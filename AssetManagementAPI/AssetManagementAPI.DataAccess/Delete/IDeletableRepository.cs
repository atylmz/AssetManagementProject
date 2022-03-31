using AssetManagementAPI.DataAccess.Repository.IRepository;
using AssetManagementAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Delete
{
    public interface IDeletableRepository<T> : IRepository<T> where T : class, IEntity
    {
        void SoftDelete(int Id);
    }
}
