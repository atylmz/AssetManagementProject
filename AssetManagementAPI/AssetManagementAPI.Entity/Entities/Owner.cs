using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Owner : IEntity
    {
        public Owner()
        {
            AssetOwners = new HashSet<AssetOwner>();
        }

        public int OwnerId { get; set; }
        public int? AssetOwnerId { get; set; }
        public int? TeamId { get; set; }
        public int? PersonnelId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<AssetOwner> AssetOwners { get; set; }
    }
}
