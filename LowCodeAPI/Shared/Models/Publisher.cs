using System;
using System.Collections.Generic;

#nullable disable

namespace LowCodeAPI.Shared.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Employees = new HashSet<Employee>();
            Titles = new HashSet<Title>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual PubInfo PubInfo { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
    }
}
