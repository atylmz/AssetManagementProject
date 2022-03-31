using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Company : IEntity
    {
        public Company()
        {
            Assets = new HashSet<Asset>();
            Personnel = new HashSet<Personnel>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
