using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class CusCart
    {
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int Id { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Color Color { get; set; }
        public virtual Item Item { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Size Size { get; set; }
    }
}
