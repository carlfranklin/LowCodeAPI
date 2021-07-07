using System;
using System.Collections.Generic;

namespace LowCodeAPI.Shared.Models
{
    public partial class Roysched
    {
        public string TitleId { get; set; }
        public int? Lorange { get; set; }
        public int? Hirange { get; set; }
        public int? Royalty { get; set; }

        public virtual Titles Title { get; set; }
    }
}
