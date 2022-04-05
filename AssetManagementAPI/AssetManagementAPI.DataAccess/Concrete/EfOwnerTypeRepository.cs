using AssetManagementAPI.DataAccess.Abstract;
using AssetManagementAPI.DataAccess.Repository.Repository;
using AssetManagementAPI.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Concrete
{
    public class EfOwnerTypeRepository : Repository<OwnerType>, IOwnerTypeRepository
    {
        public EfOwnerTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
