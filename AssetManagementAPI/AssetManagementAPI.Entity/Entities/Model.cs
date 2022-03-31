﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class Model : IEntity
    {
        public Model()
        {
            Assets = new HashSet<Asset>();
        }

        public int ModelId { get; set; }
        public int? BrandId { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
