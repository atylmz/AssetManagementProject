using AssetManagementAPI.DataAccess.Abstract;
using AssetManagementAPI.DataAccess.Concrete;
using AssetManagementAPI.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(AssetManagementContext context)
        {
            _context = context;
            Groups = new EfGroupRepository(context);
            Types = new EfTypeRepository(context);
            Brands = new EfBrandRepository(context);
            Models = new EfModelRepository(context);
            Currencies = new EfCurrencyRepository(context);
            Units = new EfUnitRepository(context);
            Assets = new EfAssetRepository(context);
            AssetBarcodes = new EfAssetBarcodeRepository(context);
            AssetStatus = new EfAssetStatusRepository(context);
            Prices = new EfPriceRepository(context);
            Auth = new AuthRepository(context);
        }

        public IGroupRepository Groups { get; private set; }
        public ITypeRepository Types { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public IModelRepository Models { get; private set; }
        public ICurrencyRepository Currencies { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IAssetRepository Assets { get; private set; }
        public IAssetBarcodeRepository AssetBarcodes { get; private set; }
        public IAssetWithoutBarcodeRepository AssetWithoutBarcodes { get; private set; }
        public IAssetStatusRepository AssetStatus { get; private set; }
        public IPriceRepository Prices { get; private set; }
        public IAuthRepository Auth { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
