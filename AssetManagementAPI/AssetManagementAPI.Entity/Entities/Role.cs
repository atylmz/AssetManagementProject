using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Role : IEntity
    {
        public Role()
        {
            RolePersonnel = new HashSet<RolePersonnel>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RolePersonnel> RolePersonnel { get; set; }
    }
}
