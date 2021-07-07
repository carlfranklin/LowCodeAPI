using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Employee = new HashSet<Employee>();
        }

        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
