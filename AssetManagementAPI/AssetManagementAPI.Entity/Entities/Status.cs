using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Status : IEntity
    {
        public Status()
        {
            ActionStatuses = new HashSet<ActionStatus>();
            AssetStatuses = new HashSet<AssetStatus>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }
        public int? Code { get; set; }
        public bool? IsMaster { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ActionStatus> ActionStatuses { get; set; }
        public virtual ICollection<AssetStatus> AssetStatuses { get; set; }
    }
}
