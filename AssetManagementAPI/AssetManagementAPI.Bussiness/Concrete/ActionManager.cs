using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Messages;
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AssetManagementAPI.Bussiness.Concrete
{
   public class ActionManager : IActionService
    {
        private readonly IUnitOfWork _uow;

        public ActionManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddAction(Action entity)
        {

            try
            {


                _uow.Actions.Add(entity);
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
            catch (System.Exception ex)
            {

                return new ErrorResult(ex, Message.Failed);
            }

        }

        public IResult DeleteAction(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Actions.SoftDelete(entity);
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
                catch (System.Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
        }

        public IDataResult<List<Action>> GetAllActions()
        {
            try
            {
                return new SuccessDataResult<List<Action>>(_uow.Actions.GetAll());
            }
            catch (System.Exception ex)
            {

                return new ErrorDataResult<List<Action>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Action> GetActionById(int id)
        {
            try
            {
                return new SuccessDataResult<Action>(_uow.Actions.GetById(id));
            }
            catch (System.Exception ex)
            {

                return new ErrorDataResult<Action>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAction(Action entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Actions.Update(entity);
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
                catch (System.Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
        }
    }
}
