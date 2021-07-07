using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LowCodeAPI.Shared.Models;

namespace LowCodeAPI.Server.Data
{
    public partial class pubsContext : DbContext
    {
        public pubsContext()
        {
        }

        public pubsContext(DbContextOptions<pubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfo { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Roysched> Roysched { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Titleauthor> Titleauthor { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<Titleview> Titleview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.ToTable("authors");

                entity.HasIndex(e => new { e.AuLname, e.AuFname })
                    .HasName("aunmind");

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasColumnName("au_fname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasColumnName("au_lname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Contract).HasColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('UNKNOWN')");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("discounts");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Discounttype)
                    .IsRequired()
                    .HasColumnName("discounttype")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Highqty).HasColumnName("highqty");

                entity.Property(e => e.Lowqty).HasColumnName("lowqty");

                entity.Property(e => e.StorId)
                    .HasColumnName("stor_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Stor)
                    .WithMany()
                    .HasForeignKey(d => d.StorId)
                    .HasConstraintName("FK__discounts__stor___3B75D760");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id")
                    .IsClustered(false);

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit })
                    .HasName("employee_ind")
                    .IsClustered();

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JobLvl)
                    .HasColumnName("job_lvl")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Minit)
                    .HasColumnName("minit")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('9952')");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__job_id__47DBAE45");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__pub_id__4AB81AF0");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__jobs__6E32B6A5DE9FF80F");

                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasColumnName("job_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('New Position - title not formalized yet')");

                entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
            });

            modelBuilder.Entity<PubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.PrInfo)
                    .HasColumnName("pr_info")
                    .HasColumnType("text");

                entity.HasOne(d => d.Pub)
                    .WithOne(p => p.PubInfo)
                    .HasForeignKey<PubInfo>(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pub_info__pub_id__4316F928");
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasColumnName("pub_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Roysched>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roysched");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");

                entity.Property(e => e.Hirange).HasColumnName("hirange");

                entity.Property(e => e.Lorange).HasColumnName("lorange");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.TitleId)
                    .IsRequired()
                    .HasColumnName("title_id")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Title)
                    .WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__roysched__title___398D8EEE");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId })
                    .HasName("UPKCL_sales");

                entity.ToTable("sales");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");

                entity.Property(e => e.StorId)
                    .HasColumnName("stor_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrdNum)
                    .HasColumnName("ord_num")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.OrdDate)
                    .HasColumnName("ord_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Payterms)
                    .IsRequired()
                    .HasColumnName("payterms")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Stor)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__stor_id__36B12243");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__title_id__37A5467C");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");

                entity.ToTable("stores");

                entity.Property(e => e.StorId)
                    .HasColumnName("stor_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StorAddress)
                    .HasColumnName("stor_address")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StorName)
                    .HasColumnName("stor_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Titleauthor>(entity =>
            {
                entity.HasKey(e => new { e.AuId, e.TitleId })
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuId)
                    .HasName("auidind");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titleauthor)
                    .HasForeignKey(d => d.AuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__au_id__30F848ED");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Titleauthor)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__title__31EC6D26");
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("UPKCL_titleidind");

                entity.ToTable("titles");

                entity.HasIndex(e => e.Title)
                    .HasName("titleind");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Advance)
                    .HasColumnName("advance")
                    .HasColumnType("money");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pubdate)
                    .HasColumnName("pubdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('UNDECIDED')");

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__titles__pub_id__2D27B809");
            });

            modelBuilder.Entity<Titleview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("titleview");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasColumnName("au_lname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
