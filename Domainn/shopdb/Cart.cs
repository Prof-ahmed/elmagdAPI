using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Cart
    {
        public Cart()
        {
            CusCarts = new HashSet<CusCart>();
        }

        public int Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? ItemsNumber { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CusCart> CusCarts { get; set; }
    }
}
