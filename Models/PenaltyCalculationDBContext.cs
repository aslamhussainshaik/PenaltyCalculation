using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PenaltyCalculation.Repos
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

        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=PenaltyCalculationDB;User Id=postgres;Password=dummytransactionpenalty;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("RegistrationTable");

                entity.HasIndex(e => e.EmailId, "Email_Id")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .HasColumnName("Email Id")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Placeofholdingtechnumber)
                    .HasName("transaction_pkey");

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
                    .HasColumnName("isin");

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
                    .HasColumnType("money")
                    .HasColumnName("penaltyamount");

                entity.Property(e => e.Securityquantity).HasColumnName("securityquantity");

                entity.Property(e => e.Settlement).HasColumnName("settlement");

                entity.Property(e => e.Settlementcashamount)
                    .HasColumnType("money")
                    .HasColumnName("settlementcashamount");

                entity.Property(e => e.Sign)
                    .HasMaxLength(2)
                    .HasColumnName("sign");

                entity.Property(e => e.Transactiontypecode)
                    .HasMaxLength(4)
                    .HasColumnName("transactiontypecode")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
