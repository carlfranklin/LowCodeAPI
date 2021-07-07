using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Stores
    {
        public Stores()
        {
            Sales = new HashSet<Sales>();
        }

        public string StorId { get; set; }
        public string StorName { get; set; }
        public string StorAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
