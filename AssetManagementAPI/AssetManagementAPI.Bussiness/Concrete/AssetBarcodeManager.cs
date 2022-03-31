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
    public class AssetBarcodeManager : IAssetBarcodeService
    {
        private readonly IUnitOfWork _uow;

        public AssetBarcodeManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddAssetBarcode(AssetBarcode entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetBarcodes.Add(entity);
                    int a =_uow.SaveChanges();
                    if (a > 0)
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

        public IResult DeleteAssetBarcode(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetBarcodes.SoftDelete(entity);
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

        public IDataResult<List<AssetBarcode>> GetAllAssetBarcodes()
        {
            try
            {
                return new SuccessDataResult<List<AssetBarcode>>(_uow.AssetBarcodes.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<AssetBarcode>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<AssetBarcode> GetAssetBarcodeById(int id)
        {
            try
            {
                return new SuccessDataResult<AssetBarcode>(_uow.AssetBarcodes.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AssetBarcode>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAssetBarcode(AssetBarcode entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetBarcodes.Update(entity);
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
