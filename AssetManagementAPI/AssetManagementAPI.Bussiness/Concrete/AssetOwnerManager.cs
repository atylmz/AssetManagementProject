using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Messages;
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.DtoModel.DTO.AssetOwnerDTO;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AssetManagementAPI.Bussiness.Concrete
{
    public class AssetOwnerManager :IAssetOwnerService
    {
        private readonly IUnitOfWork _uow;

        public AssetOwnerManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddAssetOwner(AssetOwner entity)
        {

            try
            {
                _uow.AssetOwner.Add(entity);
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

        public IResult DeleteAssetOwner(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetOwner.SoftDelete(entity);
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

        public IDataResult<List<AssetOwner>> GetAllAssetOwners()
        {
            try
            {
                return new SuccessDataResult<List<AssetOwner>>(_uow.AssetOwner.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<AssetOwner>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<AssetOwner> GetAssetOwnerById(int id)
        {
            try
            {
                return new SuccessDataResult<AssetOwner>(_uow.AssetOwner.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AssetOwner>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateAssetOwner(AssetOwner entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.AssetOwner.Update(entity);
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
        public IResult AssetOwnerAdder(AssetOwnerDTO dto)
        {
            using(TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Owners.Add(new Owner()
                    {
                        PersonnelId = dto.PersonnelId,
                        TeamId = dto.TeamId,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                    });
                    _uow.SaveChanges();
                    int ownerId = _uow.Owners.GetAll().OrderByDescending(x => x.OwnerId).Select(x => x.OwnerId).Take(1).FirstOrDefault();
                    _uow.AssetOwner.Add(new AssetOwner()
                    {
                        AssetId = dto.AssetId,
                        OwnerId = ownerId,
                        OwnerTypeId = dto.OwnerTypeId,
                        Date = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                    });
                    _uow.SaveChanges();
                    scope.Complete();
                    return new SuccessResult(Message.Added);
                }
                catch (Exception ex)
                {

                    return new ErrorResult(ex, Message.Failed);
                }
            }
           
            
        }
    }
}
