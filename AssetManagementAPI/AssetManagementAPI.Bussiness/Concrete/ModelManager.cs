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
    public class ModelManager : IModelService
    {
        private readonly IUnitOfWork _uow;

        public ModelManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddModel(Model entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Models.Add(entity);
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

        public IResult DeleteModel(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Models.SoftDelete(entity);
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

        public IDataResult<List<Model>> GetAllModels()
        {
            try
            {
                return new SuccessDataResult<List<Model>>(_uow.Models.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Model>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Model> GetModelById(int id)
        {
            try
            {
                return new SuccessDataResult<Model>(_uow.Models.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Model>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateModel(Model entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Models.Update(entity);
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
