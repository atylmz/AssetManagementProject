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
    public class StatusManager : IStatusService
    {
        private readonly IUnitOfWork _uow;
        public StatusManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IResult AddStatus(Status entity)
        {

            try
            {


                _uow.Status.Add(entity);
                int a = _uow.SaveChanges();



                if (a > 0)
                {

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

        public IResult DeleteStatus(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Status.SoftDelete(entity);
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

        public IDataResult<List<Status>> GetAllStatuss()
        {
            try
            {
                return new SuccessDataResult<List<Status>>(_uow.Status.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Status>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Status> GetStatusById(int id)
        {
            try
            {
                return new SuccessDataResult<Status>(_uow.Status.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Status>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateStatus(Status entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Status.Update(entity);
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
