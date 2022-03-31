using AssetManagementAPI.DataAccess.Add;
using AssetManagementAPI.DataAccess.Delete;
using AssetManagementAPI.DataAccess.Select;
using AssetManagementAPI.DataAccess.Update;
using AssetManagementAPI.Entity;
using AssetManagementAPI.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.Repository.Repository
{
    public class Repository <TEntity> : IAddableRepository<TEntity>, IDeletableRepository<TEntity>, IUpdatableRepository<TEntity>, ISelectableRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext _context;
    public Repository(DbContext context)
    {
            _context = context;
    }
    

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> condition)
    {
        return _context.Set<TEntity>().SingleOrDefault(condition);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null)
    {
        return condition == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(condition).ToList();
    }

    public TEntity GetById(int Id)
    {
        return _context.Set<TEntity>().Find(Id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void SoftDelete(int Id)
    {
        var entity = _context.Set<TEntity>().Find(Id);
        entity.GetType().GetProperty("IsActive").SetValue(entity, false);
        Update(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
}
