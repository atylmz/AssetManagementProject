using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class AssetOwner : IEntity
    {
        public int AssetOwnerId { get; set; }
        public int? AssetId { get; set; }
        public int? OwnerId { get; set; }
        public int? OwnerTypeId { get; set; }
        public DateTime? Date { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual OwnerType OwnerType { get; set; }
    }
}
