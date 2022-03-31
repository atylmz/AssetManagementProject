using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class PersonnelTeam : IEntity
    {
        public int PersonnelTeamId { get; set; }
        public int? PersonnelId { get; set; }
        public int? TeamId { get; set; }
        public DateTime? Date { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual Team Team { get; set; }
    }
}
