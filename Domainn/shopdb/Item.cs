using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Item
    {
        public Item()
        {
            CusCarts = new HashSet<CusCart>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public int? BrandId { get; set; }
        public string ItemDescription { get; set; }
        public string PicName { get; set; }
        public int? Price { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<CusCart> CusCarts { get; set; }
    }
}
