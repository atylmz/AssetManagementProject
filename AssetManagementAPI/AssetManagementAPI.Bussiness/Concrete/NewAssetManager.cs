using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Messages;
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.DtoModel.DTO.AssetDTO;
using AssetManagementAPI.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AssetManagementAPI.Bussiness.Concrete
{
    public class NewAssetManager : INewAssetService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAssetService _asset;
        private readonly IAssetBarcodeService _barcode;
        private readonly IAssetWithoutBarcodeService _barcodeWithout;
        private readonly IAssetStatusService _assetStatus;
        private readonly IPriceService _price;

        public NewAssetManager(IUnitOfWork uow, IAssetService asset, IAssetWithoutBarcodeService barcodeWithout, IAssetBarcodeService barcode, IAssetStatusService assetStatus, IPriceService price)
        {
            _uow = uow;
            _asset = asset;
            _barcodeWithout = barcodeWithout;
            _barcode = barcode;
            _assetStatus = assetStatus;
            _price = price;
        }

        public IResult NewAssetAdd(NewAssetDTO dto)
        {
           
                _asset.AddAsset(new Asset()
                {
                    CompanyId = dto.CompanyId,
                    GroupId = dto.GroupId,
                    TypeId = dto.TypeId,
                    BrandId = dto.BrandId,
                    ModelId = dto.ModelId,
                    CurrencyId = dto.CurrencyId,
                    Description = dto.Description,
                    Cost = dto.Cost,
                    Guarantee = dto.Guarantee,
                    EntryDate = dto.EntryDate,
                    RetireDate = dto.RetireDate,
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedDate = dto.ModifiedDate,
                });
                int lastId = _asset.GetAllAssets().Data.OrderByDescending(x => x.AssetId).Select(x => x.AssetId).Take(1).FirstOrDefault();
                _assetStatus.AddAssetStatus(new AssetStatus()
                {
                    AssetId = lastId,
                    PersonnelId = dto.PersonnelId,
                    StatusId = dto.StatusId,
                    Note = dto.Note,
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedDate = dto.ModifiedDate,
                });
                _price.AddPrice(new Price()
                {
                    AssetId = lastId,
                    CurrencyId = dto.PriceCurrencyId,
                    Price1 = dto.Price1,
                    Date = dto.Date,
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedDate = dto.ModifiedDate,
                });
                if (dto.Barcode != null)
                {
                    _barcode.AddAssetBarcode(new AssetBarcode()
                    {
                        AssetId = lastId,
                        Barcode = dto.Barcode,
                        CreatedBy = dto.CreatedBy,
                        CreatedDate = dto.CreatedDate,
                        ModifiedBy = dto.ModifiedBy,
                        ModifiedDate = dto.ModifiedDate,
                    });
                }
                else
                {
                    _barcodeWithout.AddAssetWithoutBarcode(new AssetWithoutBarcode()
                    {
                        AssetId = lastId,
                        UnitId = dto.UnitId,
                        Quantity = dto.Quantity,
                        CreatedBy = dto.CreatedBy,
                        CreatedDate = dto.CreatedDate,
                        ModifiedBy = dto.ModifiedBy,
                        ModifiedDate = dto.ModifiedDate,
                    });
                }
                return new SuccessResult(Message.Added);

            
            
        }
    }
}
