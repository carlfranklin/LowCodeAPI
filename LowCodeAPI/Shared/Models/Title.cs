using System;
using System.Collections.Generic;

#nullable disable

namespace LowCodeAPI.Shared.Models
{
    public partial class Title
    {
        public Title()
        {
            Sales = new HashSet<Sale>();
            Titleauthors = new HashSet<Titleauthor>();
        }

        public string TitleId { get; set; }
        public string Title1 { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }

        public virtual Publisher Pub { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Titleauthor> Titleauthors { get; set; }
    }
}
