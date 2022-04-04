using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Personnel : IEntity
    {
        public Personnel()
        {
            AssetStatuses = new HashSet<AssetStatus>();
            Comments = new HashSet<Comment>();
            Communications = new HashSet<Communication>();
            Owners = new HashSet<Owner>();
            PersonnelTeams = new HashSet<PersonnelTeam>();
            RolePersonnel = new HashSet<RolePersonnel>();
        }

        public int PersonnelId { get; set; }
        public int? CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username{ get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<AssetStatus> AssetStatuses { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Communication> Communications { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<PersonnelTeam> PersonnelTeams { get; set; }
        public virtual ICollection<RolePersonnel> RolePersonnel { get; set; }
    }
}
