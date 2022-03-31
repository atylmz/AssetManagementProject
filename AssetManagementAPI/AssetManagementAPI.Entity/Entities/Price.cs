using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Price : IEntity
    {
        public int PriceId { get; set; }
        public int? AssetId { get; set; }
        public decimal? Price1 { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? Date { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
