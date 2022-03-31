using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class RolePersonnel : IEntity
    {
        public int RolePersonnelId { get; set; }
        public int? PersonnelId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Date { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual Role Role { get; set; }
    }
}
