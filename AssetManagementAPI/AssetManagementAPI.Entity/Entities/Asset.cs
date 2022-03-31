using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Asset : IEntity
    {
        public Asset()
        {
            AssetBarcodes = new HashSet<AssetBarcode>();
            AssetCustomers = new HashSet<AssetCustomer>();
            AssetOwners = new HashSet<AssetOwner>();
            AssetStatuses = new HashSet<AssetStatus>();
            AssetWithoutBarcodes = new HashSet<AssetWithoutBarcode>();
            Comments = new HashSet<Comment>();
            Prices = new HashSet<Price>();
        }

        public int AssetId { get; set; }
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
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Company Company { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Group Group { get; set; }
        public virtual Model Model { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<AssetBarcode> AssetBarcodes { get; set; }
        public virtual ICollection<AssetCustomer> AssetCustomers { get; set; }
        public virtual ICollection<AssetOwner> AssetOwners { get; set; }
        public virtual ICollection<AssetStatus> AssetStatuses { get; set; }
        public virtual ICollection<AssetWithoutBarcode> AssetWithoutBarcodes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
