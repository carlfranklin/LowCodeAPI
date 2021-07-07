using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Titleauthor = new HashSet<Titleauthor>();
        }

        public string AuId { get; set; }
        public string AuLname { get; set; }
        public string AuFname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Contract { get; set; }

        public virtual ICollection<Titleauthor> Titleauthor { get; set; }
    }
}
