﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testEF.Models;

namespace testEF.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20180811055538_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testEF.Models.Department", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DEPARTMENT");
                });

            modelBuilder.Entity("testEF.Models.Department2", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DEPARTMENT_2");
                });

            modelBuilder.Entity("testEF.Models.Doctors", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnName("DOCTOR_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(50);

                    b.HasKey("DoctorId");

                    b.ToTable("DOCTORS");
                });

            modelBuilder.Entity("testEF.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(50);

                    b.Property<int?>("Num");

                    b.HasKey("Id");

                    b.ToTable("EMPLOYEE");
                });

            modelBuilder.Entity("testEF.Models.Employee2", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("DepartmentId")
                        .HasColumnName("Department_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("EMPLOYEE_2");
                });

            modelBuilder.Entity("testEF.Models.MapDoctorsPaients", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnName("DOCTOR_ID");

                    b.Property<int>("PatientId")
                        .HasColumnName("PATIENT_ID");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("MAP_DOCTORS_PAIENTS");
                });

            modelBuilder.Entity("testEF.Models.Patients", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnName("PATIENT_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(10);

                    b.HasKey("PatientId");

                    b.ToTable("PATIENTS");
                });

            modelBuilder.Entity("testEF.Models.Test", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Age");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TEST");
                });

            modelBuilder.Entity("testEF.Models.Employee2", b =>
                {
                    b.HasOne("testEF.Models.Department2", "Department")
                        .WithMany("Employee2")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("EMPLOYEE_2_DEPARTMENT_2_Id_fk");
                });

            modelBuilder.Entity("testEF.Models.MapDoctorsPaients", b =>
                {
                    b.HasOne("testEF.Models.Doctors", "Doctor")
                        .WithMany("MapDoctorsPaients")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_MAP_DOCTORS_PAIENTS_DOCTOR");

                    b.HasOne("testEF.Models.Patients", "Patient")
                        .WithMany("MapDoctorsPaients")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_MAP_DOCTORS_PAIENTS_PATIENT");
                });
#pragma warning restore 612, 618
        }
    }
}
