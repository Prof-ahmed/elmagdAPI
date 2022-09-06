using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CusCarts = new HashSet<CusCart>();
        }

        public int Id { get; set; }
        public string PaymentName { get; set; }
        public string PaymentDescription { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<CusCart> CusCarts { get; set; }
    }
}
