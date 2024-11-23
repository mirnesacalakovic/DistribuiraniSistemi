﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentiBackup_BGJobs;

#nullable disable

namespace StudentiBackup_BGJobs.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentiBackup_BGJobs.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImePrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Smer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentiBackup_BGJobs.Models.StudentsBackup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImePrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Smer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students_Backup");
                });
#pragma warning restore 612, 618
        }
    }
}
