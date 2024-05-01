using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Insurance_server.Models;

public partial class InsuranceDbContext : DbContext
{
    public InsuranceDbContext()
    {
    }

    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PolicyDetail> PolicyDetails { get; set; }

    public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }

 /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=INSURANCE_DB;Integrated Security=True; TrustServerCertificate=True");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FB4717E07");

            entity.ToTable("Employee_Details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employee___user___4222D4EF");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment___ED1FC9EA01D5F53E");

            entity.ToTable("Payment_Details");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("card_number");
            entity.Property(e => e.CardOwnerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("card_owner_name");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("security_code");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValidThrough).HasColumnName("valid_through");

            entity.HasOne(d => d.User).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payment_D__user___44FF419A");
        });

        modelBuilder.Entity<PolicyDetail>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Policy_D__47DA3F0386557EC1");

            entity.ToTable("Policy_Details");

            entity.Property(e => e.PolicyId)
                .ValueGeneratedNever()
                .HasColumnName("policy_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PolicyDescription)
                .HasColumnType("text")
                .HasColumnName("policy_description");
            entity.Property(e => e.PolicyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("policy_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Policy_De__user___398D8EEE");
        });

        modelBuilder.Entity<UserLoginDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User_Log__B9BE370F1F296603");

            entity.ToTable("User_Login_Details");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
