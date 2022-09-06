using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Brand
    {
        public Brand()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string BrandName { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
