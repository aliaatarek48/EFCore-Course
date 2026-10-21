using System;
using System.Collections.Generic;
using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultant> Consultants { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<DrugAdministration> DrugAdministrations { get; set; }

    public virtual DbSet<DrugBrand> DrugBrands { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<NurseDataServWardOne> NurseDataServWardOnes { get; set; }

    public virtual DbSet<NurseDatum> NurseData { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAssignedToWard> PatientAssignedToWards { get; set; }

    public virtual DbSet<PatientBasicInfoView> PatientBasicInfoViews { get; set; }

    public virtual DbSet<PatientConsultantAssignment> PatientConsultantAssignments { get; set; }

    public virtual DbSet<PatientReportDatum> PatientReportData { get; set; }

    public virtual DbSet<PatientWithWardNameView> PatientWithWardNameViews { get; set; }

    public virtual DbSet<PatientsDrugView> PatientsDrugViews { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consulta__3214EC07C7B23124");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConName).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Drug__A25C5AA675E6519A");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Dosage).HasMaxLength(50);
        });

        modelBuilder.Entity<DrugAdministration>(entity =>
        {
            entity.HasKey(e => new { e.NurseId, e.DrugCode, e.PatientId, e.Date, e.Time }).HasName("PK_Gives");

            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Dosage).HasMaxLength(50);

            entity.HasOne(d => d.DrugCodeNavigation).WithMany(p => p.DrugAdministrations)
                .HasForeignKey(d => d.DrugCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Drug");

            entity.HasOne(d => d.Nurse).WithMany(p => p.DrugAdministrations)
                .HasForeignKey(d => d.NurseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Nurse");

            entity.HasOne(d => d.Patient).WithMany(p => p.DrugAdministrations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Patient");
        });

        modelBuilder.Entity<DrugBrand>(entity =>
        {
            entity.HasKey(e => new { e.DrugCode, e.Brand }).HasName("PK_DrugBrand");

            entity.Property(e => e.Brand).HasMaxLength(100);

            entity.HasOne(d => d.DrugCodeNavigation).WithMany(p => p.DrugBrands)
                .HasForeignKey(d => d.DrugCode)
                .HasConstraintName("FK_DrugBrand_Drug");
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Nurse__78A1A19C115514F9");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NurseAddress).HasMaxLength(200);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Nurses_Manager");

            entity.HasOne(d => d.ServesInWard).WithMany(p => p.NurseServesInWards)
                .HasForeignKey(d => d.ServesInWardId)
                .HasConstraintName("FK__Nurse__ServesInW__4BAC3F29");

            entity.HasOne(d => d.SupervisedWard).WithMany(p => p.NurseSupervisedWards)
                .HasForeignKey(d => d.SupervisedWardId)
                .HasConstraintName("FK__Nurse__Supervise__4AB81AF0");
        });

        modelBuilder.Entity<NurseDataServWardOne>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NurseDataServWardOne");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<NurseDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NurseData");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC073485B1E6");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ward).WithMany(p => p.Patients)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK__Patient__WardId__49C3F6B7");

            entity.HasMany(d => d.Consultants).WithMany(p => p.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PatientExamination",
                    r => r.HasOne<Consultant>().WithMany()
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKamine_Consultant"),
                    l => l.HasOne<Patient>().WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Examine_Patient"),
                    j =>
                    {
                        j.HasKey("PatientId", "ConsultantId").HasName("PK_Examine");
                        j.ToTable("PatientExaminations");
                    });
        });

        modelBuilder.Entity<PatientAssignedToWard>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientAssignedToWards");

            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.WardId).HasColumnName("wardId");
        });

        modelBuilder.Entity<PatientBasicInfoView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientBasicInfoView");

            entity.Property(e => e.DateOfbirth).HasColumnName("DateOFBirth");
            entity.Property(e => e.PatientName).HasMaxLength(100);
        });

        modelBuilder.Entity<PatientConsultantAssignment>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK_PatientConsultantAssignments_1");

            entity.Property(e => e.PatientId).ValueGeneratedNever();

            entity.HasOne(d => d.Consultant).WithMany(p => p.PatientConsultantAssignments)
                .HasForeignKey(d => d.ConsultantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assigned_Consultant");

            entity.HasOne(d => d.Patient).WithOne(p => p.PatientConsultantAssignment)
                .HasForeignKey<PatientConsultantAssignment>(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assigned_Patient");
        });

        modelBuilder.Entity<PatientReportDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientReportData");

            entity.Property(e => e.AssignedConsultant).HasMaxLength(100);
            entity.Property(e => e.AvgNurseSalary).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.ConsultantSalary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.MedicationCategory)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.SupervisorManagerName).HasMaxLength(100);
            entity.Property(e => e.SupervisorName).HasMaxLength(100);
            entity.Property(e => e.WardName).HasMaxLength(100);
        });

        modelBuilder.Entity<PatientWithWardNameView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientWithWardNameView");

            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .HasColumnName("patientName");
            entity.Property(e => e.WardName).HasMaxLength(100);
        });

        modelBuilder.Entity<PatientsDrugView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientsDrugView");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ward__3214EC070D021CBC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
