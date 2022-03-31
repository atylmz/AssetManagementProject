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
    public class CurrencyManager : ICurrencyService
    {
        private readonly IUnitOfWork _uow;

        public CurrencyManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddCurrency(Currency entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Currencies.Add(entity);
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

        public IResult DeleteCurrency(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Currencies.SoftDelete(entity);
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

        public IDataResult<List<Currency>> GetAllCurrencies()
        {
            try
            {
                return new SuccessDataResult<List<Currency>>(_uow.Currencies.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Currency>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Currency> GetCurrencyById(int id)
        {
            try
            {
                return new SuccessDataResult<Currency>(_uow.Currencies.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Currency>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateCurrency(Currency entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Currencies.Update(entity);
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
