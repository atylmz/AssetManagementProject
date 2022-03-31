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
    public class AssetWithoutBarcodeManager : IAssetWithoutBarcodeService
    {
        private readonly IUnitOfWork _uow;

        public AssetWithoutBarcodeManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddAssetWithoutBarcode(AssetWithoutBarcode entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetWithoutBarcodes.Add(entity);
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

        public IResult DeleteAssetWithoutBarcode(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetWithoutBarcodes.SoftDelete(entity);
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

        public IDataResult<List<AssetWithoutBarcode>> GetAllAssetWithoutBarcodes()
        {
            try
            {
                return new SuccessDataResult<List<AssetWithoutBarcode>>(_uow.AssetWithoutBarcodes.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<AssetWithoutBarcode>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<AssetWithoutBarcode> GetAssetWithoutBarcodeById(int id)
        {
            try
            {
                return new SuccessDataResult<AssetWithoutBarcode>(_uow.AssetWithoutBarcodes.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AssetWithoutBarcode>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAssetWithoutBarcode(AssetWithoutBarcode entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetWithoutBarcodes.Update(entity);
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
