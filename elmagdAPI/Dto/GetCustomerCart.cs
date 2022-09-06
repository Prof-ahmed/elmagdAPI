using Domain.shopdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elmagdAPI.Dto
{
    public class GetCustomerCart
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public string ItemName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string PaymentMethodName { get; set; }
        public Cart Cart { get; set; }
    }
}
