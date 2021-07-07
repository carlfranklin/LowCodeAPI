using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Publishers
    {
        public Publishers()
        {
            Employee = new HashSet<Employee>();
            Titles = new HashSet<Titles>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual PubInfo PubInfo { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Titles> Titles { get; set; }
    }
}
