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
    public class AssetStatusManager : IAssetStatusService
    {
        private readonly IUnitOfWork _uow;

        public AssetStatusManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddAssetStatus(AssetStatus entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetStatus.Add(entity);
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

        public IResult DeleteAssetStatus(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetStatus.SoftDelete(entity);
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

        public IDataResult<List<AssetStatus>> GetAllAssetStatuss()
        {
            try
            {
                return new SuccessDataResult<List<AssetStatus>>(_uow.AssetStatus.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<AssetStatus>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<AssetStatus> GetAssetStatusById(int id)
        {
            try
            {
                return new SuccessDataResult<AssetStatus>(_uow.AssetStatus.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AssetStatus>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAssetStatus(AssetStatus entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetStatus.Update(entity);
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
