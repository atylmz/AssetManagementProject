using AssetManagementAPI.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepository Groups { get; }
        ITypeRepository Types { get; }
        IBrandRepository Brands { get; }
        IModelRepository Models { get; }
        ICurrencyRepository Currencies { get; }
        IAssetRepository Assets { get; }
        IUnitRepository Units { get; }
        IAssetBarcodeRepository AssetBarcodes { get; }
        IAssetWithoutBarcodeRepository AssetWithoutBarcodes { get; }
        IAssetStatusRepository AssetStatus { get; }
        IPriceRepository Prices { get; }
        int SaveChanges();
    }
}
