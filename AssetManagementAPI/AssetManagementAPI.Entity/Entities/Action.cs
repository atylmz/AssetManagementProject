using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Action : IEntity
    {
        public Action()
        {
            ActionStatuses = new HashSet<ActionStatus>();
        }

        public int ActionId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ActionStatus> ActionStatuses { get; set; }
    }
}
