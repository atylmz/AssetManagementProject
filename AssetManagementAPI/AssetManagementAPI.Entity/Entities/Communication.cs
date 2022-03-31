using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Communication : IEntity
    {
        public int CommunicationId { get; set; }
        public int? PersonnelId { get; set; }
        public int? CommTypeId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual CommType CommType { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
