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
    public class UnitManager : IUnitService
    {
        private readonly IUnitOfWork _uow;

        public UnitManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddUnit(Unit entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Units.Add(entity);
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

        public IResult DeleteUnit(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Units.SoftDelete(entity);
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

        public IDataResult<List<Unit>> GetAllUnits()
        {
            try
            {
                return new SuccessDataResult<List<Unit>>(_uow.Units.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Unit>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Unit> GetUniteById(int id)
        {
            try
            {
                return new SuccessDataResult<Unit>(_uow.Units.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Unit>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateUnit(Unit entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Units.Update(entity);
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
