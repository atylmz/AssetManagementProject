using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Messages;
using AssetManagementAPI.Core.Result;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.DtoModel.DTO.AssetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Bussiness.Concrete
{
    public class ListOfAssets : IListOfAssetsService
    {
        private readonly IUnitOfWork _uow;

        public ListOfAssets(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IDataResult<List<AllAssetListDTO>> AllAssetList()
        {
            List<AllAssetListDTO> assets = new List<AllAssetListDTO>();
            assets = (from a in _uow.Assets.GetAll()
                                join t in _uow.Types.GetAll() on a.TypeId equals t.TypeId
                                join b in _uow.Brands.GetAll() on a.BrandId equals b.BrandId
                                join m in _uow.Models.GetAll() on a.ModelId equals m.ModelId
                                join p in _uow.Prices.GetAll() on a.AssetId equals p.AssetId
                                select new AllAssetListDTO()
                                {
                                    AssetId = a.AssetId,
                                    Brand = b.Description,
                                    Model = m.Description,
                                    AssetType = t.Description,
                                    Price = p.Price1
                                }).ToList();
            var barcode = (from b in _uow.AssetBarcodes.GetAll()
                           select new
                           {
                                AssetId = b.AssetId,
                                Barcode = b.Barcode
                           }).ToList();
            foreach (var item in barcode)
            {
                foreach (var item2 in assets)
                {
                    if(item.AssetId == item2.AssetId)
                    {
                        item2.Barcode = item.Barcode;
                    }
                }
            }
           
            return new SuccessDataResult<List<AllAssetListDTO>>(assets);

        }
    }
}
