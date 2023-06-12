using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PenaltyCalculation.Models
{
    public partial class PenaltyCalculationDBContext : DbContext
    {
        public PenaltyCalculationDBContext()
        {
        }

        public PenaltyCalculationDBContext(DbContextOptions<PenaltyCalculationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Holidaycalendar> Holidaycalendars { get; set; } = null!;
        public virtual DbSet<Logger> Loggers { get; set; } = null!;
        public virtual DbSet<Securitypenaltyrate> Securitypenaltyrates { get; set; } = null!;
        public virtual DbSet<Securityprice> Securityprices { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=PenaltyCalculationDB;User Id=postgres;Password=aslam4177;");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .HasMaxLength(12)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Holidaycalendar>(entity =>
            {
                entity.ToTable("holidaycalendar");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.Holidaydate).HasColumnName("holidaydate");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdateddate).HasColumnName("lastupdateddate");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Holidaycalendars)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("countryid");
            });

            modelBuilder.Entity<Logger>(entity =>
            {
                entity.ToTable("logger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accessdate).HasColumnName("accessdate");

                entity.Property(e => e.Accesspage)
                    .HasMaxLength(20)
                    .HasColumnName("accesspage")
                    .IsFixedLength();

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserName)
                    .HasMaxLength(12)
                    .HasColumnName("user_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Securitypenaltyrate>(entity =>
            {
                entity.HasKey(e => e.Securitypenaltyid)
                    .HasName("securitypenaltyrate_securityid_pk");

                entity.ToTable("securitypenaltyrate");

                entity.Property(e => e.Securitypenaltyid).HasColumnName("securitypenaltyid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdateddate).HasColumnName("lastupdateddate");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Penaltyrate)
                    .HasPrecision(12)
                    .HasColumnName("penaltyrate");

                entity.Property(e => e.Validfrom).HasColumnName("validfrom");
            });

            modelBuilder.Entity<Securityprice>(entity =>
            {
                entity.ToTable("securityprice");

                entity.Property(e => e.Securitypriceid).HasColumnName("securitypriceid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.IsinSecId)
                    .HasMaxLength(12)
                    .HasColumnName("isin_sec_id")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Securityprice1)
                    .HasPrecision(12)
                    .HasColumnName("securityprice");

                entity.Property(e => e.ValidFromDate).HasColumnName("valid_from_date");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Placeofholdingtechnumber)
                    .HasName("transaction_reports_pohtn_pk");

                entity.ToTable("transaction");

                entity.Property(e => e.Placeofholdingtechnumber).HasColumnName("placeofholdingtechnumber");

                entity.Property(e => e.Calendarid)
                    .HasMaxLength(10)
                    .HasColumnName("calendarid")
                    .IsFixedLength();

                entity.Property(e => e.Counterpartyid)
                    .HasMaxLength(16)
                    .HasColumnName("counterpartyid")
                    .IsFixedLength();

                entity.Property(e => e.Counterpartyrolecd)
                    .HasMaxLength(6)
                    .HasColumnName("counterpartyrolecd")
                    .IsFixedLength();

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(20)
                    .HasColumnName("createdby")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon");

                entity.Property(e => e.Failingpartyrolecd)
                    .HasMaxLength(6)
                    .HasColumnName("failingpartyrolecd")
                    .IsFixedLength();

                entity.Property(e => e.Instructiontypecode)
                    .HasMaxLength(4)
                    .HasColumnName("instructiontypecode")
                    .IsFixedLength();

                entity.Property(e => e.Isin)
                    .HasMaxLength(12)
                    .HasColumnName("isin")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdatedby")
                    .IsFixedLength();

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lastupdatedon")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.LoggerId).HasColumnName("logger_id");

                entity.Property(e => e.Matchingreference)
                    .HasMaxLength(16)
                    .HasColumnName("matchingreference")
                    .IsFixedLength();

                entity.Property(e => e.Partyid)
                    .HasMaxLength(16)
                    .HasColumnName("partyid")
                    .IsFixedLength();

                entity.Property(e => e.Partyrolecd)
                    .HasMaxLength(6)
                    .HasColumnName("partyrolecd")
                    .IsFixedLength();

                entity.Property(e => e.Penaltyamount)
                    .HasPrecision(10)
                    .HasColumnName("penaltyamount");

                entity.Property(e => e.Placeofsettlement)
                    .HasMaxLength(11)
                    .HasColumnName("placeofsettlement")
                    .IsFixedLength();

                entity.Property(e => e.Securitypenaltyid).HasColumnName("securitypenaltyid");

                entity.Property(e => e.Securitypriceid).HasColumnName("securitypriceid");

                entity.Property(e => e.Securityquantity).HasColumnName("securityquantity");

                entity.Property(e => e.Settlementcashamount)
                    .HasPrecision(10)
                    .HasColumnName("settlementcashamount");

                entity.Property(e => e.Settlementdate).HasColumnName("settlementdate");

                entity.Property(e => e.Sign)
                    .HasMaxLength(4)
                    .HasColumnName("sign")
                    .IsFixedLength();

                entity.Property(e => e.Transactiontypecode)
                    .HasMaxLength(4)
                    .HasColumnName("transactiontypecode")
                    .IsFixedLength();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Countryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_country_countryid_fk");

                entity.HasOne(d => d.Logger)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.LoggerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_logger_id");

                entity.HasOne(d => d.Securitypenalty)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Securitypenaltyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_securitypenaltyrate_securitypenaltyid_fk");

                entity.HasOne(d => d.Securityprice)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Securitypriceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_securityprice_securitypriceid_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
