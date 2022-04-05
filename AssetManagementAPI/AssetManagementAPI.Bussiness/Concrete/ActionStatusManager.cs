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
    public class ActionStatusManager : IActionStatusService
    {
        private readonly IUnitOfWork _uow;

        public ActionStatusManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddActionStatus(ActionStatus entity)
        {

            try
            {


                _uow.ActionStatus.Add(entity);
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

        public IResult DeleteActionStatus(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.ActionStatus.SoftDelete(entity);
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

        public IDataResult<List<ActionStatus>> GetAllActionStatuss()
        {
            try
            {
                return new SuccessDataResult<List<ActionStatus>>(_uow.ActionStatus.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<ActionStatus>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<ActionStatus> GetActionStatusById(int id)
        {
            try
            {
                return new SuccessDataResult<ActionStatus>(_uow.ActionStatus.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<ActionStatus>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateActionStatus(ActionStatus entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.ActionStatus.Update(entity);
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
