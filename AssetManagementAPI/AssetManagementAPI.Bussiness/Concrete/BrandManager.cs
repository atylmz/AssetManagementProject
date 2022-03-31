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
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _uow;

        public BrandManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult AddBrand(Brand entity)
        {

            try
            {
                 
               
                    _uow.Brands.Add(entity);
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

        public IResult DeleteBrand(int entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Brands.SoftDelete(entity);
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

        public IDataResult<List<Brand>> GetAllBrands()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_uow.Brands.GetAll());
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Brand>>(default, Message.Failed, ex);
            }
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            try
            {
                return new SuccessDataResult<Brand>(_uow.Brands.GetById(id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Brand>(default, Message.Failed, ex);
            }
        }

        public IResult UpdateBrand(Brand entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _uow.Brands.Update(entity);
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
