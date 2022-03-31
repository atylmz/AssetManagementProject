using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Currency : IEntity
    {
        public Currency()
        {
            Assets = new HashSet<Asset>();
            Prices = new HashSet<Price>();
        }

        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
