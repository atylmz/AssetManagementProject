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
   public class AssetManager : IAssetService
    {
        private readonly IUnitOfWork _uow;

        public AssetManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IResult AddAsset(Asset entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Assets.Add(entity);
                    int value = _uow.SaveChanges();
                    if (value > 0)
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

        public IResult DeleteAsset(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Assets.SoftDelete(entity);
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

        public IDataResult<List<Asset>> GetAllAssets()
        {
            try
            {
                return new SuccessDataResult<List<Asset>>(_uow.Assets.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Asset>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Asset> GetAssetById(int id)
        {
            try
            {
                return new SuccessDataResult<Asset>(_uow.Assets.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Asset>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAsset(Asset entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Assets.Update(entity);
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
