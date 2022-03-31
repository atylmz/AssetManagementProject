using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Models.ApiModels
{
    public class AssetFullDTO
    {
        public string Barcode { get; set; }
        public int? UnitId { get; set; }
        public decimal? Quantity { get; set; }
        public int? CompanyId { get; set; }
        public int? GroupId { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? CurrencyId { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public bool? Guarantee { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public decimal? Price1 { get; set; }
        public int? PriceCurrencyId { get; set; }
        public DateTime? Date { get; set; }
        public int? PersonnelId { get; set; }
        public int? StatusId { get; set; }
        public string Note { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
