using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elmagdAPI.Dto
{
    public class PostCustomerCart
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}
