using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Messages;
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AssetManagementAPI.Bussiness.Concrete
{
    public class TypeManager : ITypeService
    {
        private readonly IUnitOfWork _uow;
        public TypeManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddType(AssetManagementAPI.Entity.Entities.Type entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Types.Add(entity);
                    if (_uow.SaveChanges() > 0)
                    {
                        scope.Complete();
                        return new SuccessResult(Message.Added);
                    }
                    else
                    {
                        return new ErrorResult(Message.Failed);
                    }

                }
                catch (Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
        }

        public IResult DeleteType(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Types.SoftDelete(entity);
                    if (_uow.SaveChanges() > 0)
                    {
                        scope.Complete();
                        return new SuccessResult(Message.Added);
                    }
                    else
                    {
                        return new ErrorResult(Message.Failed);
                    }

                }
                catch (Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
        }

        public IDataResult<List<AssetManagementAPI.Entity.Entities.Type>> GetAllTypes()
        {
            try
            {
                return new SuccessDataResult<List<AssetManagementAPI.Entity.Entities.Type>>(_uow.Types.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<AssetManagementAPI.Entity.Entities.Type>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<AssetManagementAPI.Entity.Entities.Type> GetTypeById(int id)
        {
            try
            {
                return new SuccessDataResult<AssetManagementAPI.Entity.Entities.Type>(_uow.Types.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AssetManagementAPI.Entity.Entities.Type>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateType(AssetManagementAPI.Entity.Entities.Type entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Types.Update(entity);
                    if (_uow.SaveChanges() > 0)
                    {
                        scope.Complete();
                        return new SuccessResult(Message.Updated);
                    }
                    else
                    {
                        return new ErrorResult(Message.Failed);
                    }

                }
                catch (Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
        }
    }
}
