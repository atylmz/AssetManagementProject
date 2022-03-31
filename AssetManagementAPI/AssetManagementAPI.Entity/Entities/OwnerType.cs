using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class OwnerType : IEntity
    {
        public OwnerType()
        {
            AssetOwners = new HashSet<AssetOwner>();
        }

        public int OwnerTypeId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<AssetOwner> AssetOwners { get; set; }
    }
}
