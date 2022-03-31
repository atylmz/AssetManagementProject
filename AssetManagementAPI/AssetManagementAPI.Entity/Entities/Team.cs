using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Team : IEntity
    {
        public Team()
        {
            Owners = new HashSet<Owner>();
            PersonnelTeams = new HashSet<PersonnelTeam>();
        }

        public int TeamId { get; set; }
        public int? MasterId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<PersonnelTeam> PersonnelTeams { get; set; }
    }
}
