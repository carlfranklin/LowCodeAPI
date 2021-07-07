using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Discounts
    {
        public string Discounttype { get; set; }
        public string StorId { get; set; }
        public short? Lowqty { get; set; }
        public short? Highqty { get; set; }
        public decimal Discount { get; set; }

        public virtual Stores Stor { get; set; }
    }
}
