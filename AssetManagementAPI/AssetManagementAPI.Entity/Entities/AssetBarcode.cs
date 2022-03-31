using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class AssetBarcode : IEntity
    {
        public int AssetBarcodeId { get; set; }
        public int? AssetId { get; set; }
        public string Barcode { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }
    }
}
