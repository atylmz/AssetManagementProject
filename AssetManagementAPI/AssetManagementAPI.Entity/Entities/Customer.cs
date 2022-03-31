using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Customer : IEntity
    {
        public Customer()
        {
            AssetCustomers = new HashSet<AssetCustomer>();
        }

        public int CustomerId { get; set; }
        public int? SubscriptionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<AssetCustomer> AssetCustomers { get; set; }
    }
}
