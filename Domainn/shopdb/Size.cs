using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Size
    {
        public Size()
        {
            CusCarts = new HashSet<CusCart>();
        }

        public int Id { get; set; }
        public string SizeValue { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<CusCart> CusCarts { get; set; }
    }
}
