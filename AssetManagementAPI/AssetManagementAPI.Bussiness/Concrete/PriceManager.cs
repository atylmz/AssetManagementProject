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
    public class PriceManager : IPriceService
    {
        private readonly IUnitOfWork _uow;

        public PriceManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddPrice(Price entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Prices.Add(entity);
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

        public IResult DeletePrice(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Prices.SoftDelete(entity);
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

        public IDataResult<List<Price>> GetAllPrices()
        {
            try
            {
                return new SuccessDataResult<List<Price>>(_uow.Prices.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Price>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Price> GetPriceById(int id)
        {
            try
            {
                return new SuccessDataResult<Price>(_uow.Prices.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Price>(default, Message.Failed, ex);
            }
        }

        public IResult UpdatePrice(Price entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Prices.Update(entity);
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
