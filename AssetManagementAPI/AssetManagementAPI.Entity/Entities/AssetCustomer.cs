using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class AssetCustomer : IEntity
    {
        public int AssetCustomerId { get; set; }
        public int? AssetId { get; set; }
        public int? CustomerId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
