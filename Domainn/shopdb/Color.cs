using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.shopdb
{
    public partial class Color
    {
        public Color()
        {
            CusCarts = new HashSet<CusCart>();
        }

        public int Id { get; set; }
        public string ColorValue { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<CusCart> CusCarts { get; set; }
    }
}
