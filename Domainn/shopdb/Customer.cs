using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassward { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
