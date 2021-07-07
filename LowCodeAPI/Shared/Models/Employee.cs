using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Employee
    {
        public string EmpId { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public short JobId { get; set; }
        public byte? JobLvl { get; set; }
        public string PubId { get; set; }
        public DateTime HireDate { get; set; }

        public virtual Jobs Job { get; set; }
        public virtual Publishers Pub { get; set; }
    }
}
