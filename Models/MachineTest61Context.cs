using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MachineTest6._1.Models
{
    public partial class MachineTest61Context : DbContext
    {
        public MachineTest61Context()
        {
        }

        public MachineTest61Context(DbContextOptions<MachineTest61Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public virtual DbSet<LoanDetails> LoanDetails { get; set; }
        public virtual DbSet<Login> Login { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-KRI9FE1K\\SQLEXPRESS; Initial Catalog=MachineTest6.1; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRegistration>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Customer__213EE774473F514C");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.CustomerRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__CustomerRe__l_id__412EB0B6");
            });

            modelBuilder.Entity<LoanDetails>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__LoanDeta__A1F79554A1EE0858");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.InterestRate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__LoanDetail__c_id__440B1D61");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F838A5E5DB");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
