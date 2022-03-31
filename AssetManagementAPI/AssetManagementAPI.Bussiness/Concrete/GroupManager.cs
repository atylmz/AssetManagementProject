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
    public class GroupManager : IGroupService
    {
        private readonly IUnitOfWork _uow;

        public GroupManager(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public IResult AddGroup(Group entity)
        {
            using(TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Groups.Add(entity);
                    if(_uow.SaveChanges() > 0)
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
        public IResult UpdateGroup(Group entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Groups.Update(entity);
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

        public IResult DeleteGroup(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Groups.SoftDelete(entity);
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

        public IDataResult<Group> GetGroupById(int id)
        {
            
            try
            {
                return new SuccessDataResult<Group>(_uow.Groups.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Group>(default, Message.Failed, ex);
            }

        }

        public IDataResult<List<Group>> GetAllGroups()
        {
            try
            {
                return new SuccessDataResult<List<Group>>(_uow.Groups.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Group>>(default, Message.Failed, ex);
            }
        }
    }

}

