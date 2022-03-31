using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Comment : IEntity
    {
        public int CommentId { get; set; }
        public int? AssetId { get; set; }
        public int? PersonnelId { get; set; }
        public string Note { get; set; }
        public DateTime? Date { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
