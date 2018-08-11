using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testEF.Models
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
                : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Department2> Department2 { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employee2> Employee2 { get; set; }
        public virtual DbSet<MapDoctorsPaients> MapDoctorsPaients { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=MyDataEnt;User ID=sa;Password=P@ssw0rd;");
            }
        }

        private static Dictionary<Type, Func<object, ValidationException>> _processRouties =
                new Dictionary<Type, Func<object, ValidationException>>();

        public static void RegisterRoutie(Type t, Func<object, ValidationException> func)
        {
            _processRouties[t] = func;
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                                        .Where(a => a.State == EntityState.Added
                                                    || a.State == EntityState.Modified)
                                        .Select(a => a.Entity);

            foreach (var entity in entities)
            {
                if (_processRouties.ContainsKey(entity.GetType()))
                {
                    var exception = _processRouties[entity.GetType()].Invoke(entity);

                    if (exception != null)
                    {
                        throw exception;
                    }
                }

                // if (entity is Test test)
                // {
                //     if (test.Name.Contains("123"))
                //     {
                //        throw new ValidationException("name error"); 
                //     }
                // }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Department2>(entity =>
            {
                entity.ToTable("DEPARTMENT_2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("DOCTORS");

                entity.Property(e => e.DoctorId)
                      .HasColumnName("DOCTOR_ID")
                      .ValueGeneratedNever();

                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee2>(entity =>
            {
                entity.ToTable("EMPLOYEE_2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                      .WithMany(p => p.Employee2)
                      .HasForeignKey(d => d.DepartmentId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("EMPLOYEE_2_DEPARTMENT_2_Id_fk");
            });

            modelBuilder.Entity<MapDoctorsPaients>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.PatientId });

                entity.ToTable("MAP_DOCTORS_PAIENTS");

                entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");

                entity.HasOne(d => d.Doctor)
                      .WithMany(p => p.MapDoctorsPaients)
                      .HasForeignKey(d => d.DoctorId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MAP_DOCTORS_PAIENTS_DOCTOR");

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.MapDoctorsPaients)
                      .HasForeignKey(d => d.PatientId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MAP_DOCTORS_PAIENTS_PATIENT");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("PATIENTS");

                entity.Property(e => e.PatientId)
                      .HasColumnName("PATIENT_ID")
                      .ValueGeneratedNever();

                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(10);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("TEST");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}