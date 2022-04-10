﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projektarbete_Avancerad_.NET.API.Models;

namespace Projektarbete_Avancerad_.NET.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            Email = "jack@jack.com",
                            FirstName = "Jack",
                            LastName = "Niklasson",
                            Phone = "0750030030",
                            ProjectID = 1
                        },
                        new
                        {
                            EmployeeID = 2,
                            Email = "emma@emma.com",
                            FirstName = "Emma",
                            LastName = "Whiteside",
                            Phone = "0788484884",
                            ProjectID = 2
                        },
                        new
                        {
                            EmployeeID = 3,
                            Email = "timmo@timmo.com",
                            FirstName = "Timothy",
                            LastName = "Borgäng",
                            Phone = "0782221121",
                            ProjectID = 1
                        },
                        new
                        {
                            EmployeeID = 4,
                            Email = "alice@alice.com",
                            FirstName = "Alice",
                            LastName = "Höök",
                            Phone = "0789989899",
                            ProjectID = 3
                        },
                        new
                        {
                            EmployeeID = 5,
                            Email = "jonathan@jonthan.com",
                            FirstName = "Jonathan",
                            LastName = "Björck",
                            Phone = "0742421133",
                            ProjectID = 3
                        });
                });

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            ProjectName = "New Website"
                        },
                        new
                        {
                            ProjectID = 2,
                            ProjectName = "Car building"
                        },
                        new
                        {
                            ProjectID = 3,
                            ProjectName = "Sleep and eat"
                        });
                });

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.TimeRepEmployee", b =>
                {
                    b.Property<int>("TimeRepEmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TimeReportID")
                        .HasColumnType("int");

                    b.HasKey("TimeRepEmployeeID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TimeReportID");

                    b.ToTable("TimeRepEmployees");

                    b.HasData(
                        new
                        {
                            TimeRepEmployeeID = 1,
                            EmployeeID = 1,
                            TimeReportID = 1
                        },
                        new
                        {
                            TimeRepEmployeeID = 2,
                            EmployeeID = 1,
                            TimeReportID = 2
                        },
                        new
                        {
                            TimeRepEmployeeID = 3,
                            EmployeeID = 2,
                            TimeReportID = 3
                        },
                        new
                        {
                            TimeRepEmployeeID = 4,
                            EmployeeID = 3,
                            TimeReportID = 4
                        },
                        new
                        {
                            TimeRepEmployeeID = 5,
                            EmployeeID = 4,
                            TimeReportID = 5
                        },
                        new
                        {
                            TimeRepEmployeeID = 6,
                            EmployeeID = 4,
                            TimeReportID = 6
                        },
                        new
                        {
                            TimeRepEmployeeID = 7,
                            EmployeeID = 5,
                            TimeReportID = 7
                        },
                        new
                        {
                            TimeRepEmployeeID = 8,
                            EmployeeID = 5,
                            TimeReportID = 8
                        });
                });

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.TimeReport", b =>
                {
                    b.Property<int>("TimeReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("TimeReportID");

                    b.ToTable("TimeReports");

                    b.HasData(
                        new
                        {
                            TimeReportID = 1,
                            HoursWorked = 35,
                            Week = 23
                        },
                        new
                        {
                            TimeReportID = 2,
                            HoursWorked = 43,
                            Week = 23
                        },
                        new
                        {
                            TimeReportID = 3,
                            HoursWorked = 25,
                            Week = 23
                        },
                        new
                        {
                            TimeReportID = 4,
                            HoursWorked = 12,
                            Week = 24
                        },
                        new
                        {
                            TimeReportID = 5,
                            HoursWorked = 80,
                            Week = 24
                        },
                        new
                        {
                            TimeReportID = 6,
                            HoursWorked = 22,
                            Week = 24
                        },
                        new
                        {
                            TimeReportID = 7,
                            HoursWorked = 2,
                            Week = 25
                        },
                        new
                        {
                            TimeReportID = 8,
                            HoursWorked = 333,
                            Week = 25
                        });
                });

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.Employee", b =>
                {
                    b.HasOne("Projektarbete_Avancerad_.NET.Models.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projektarbete_Avancerad_.NET.Models.TimeRepEmployee", b =>
                {
                    b.HasOne("Projektarbete_Avancerad_.NET.Models.Employee", "Employee")
                        .WithMany("TimeRepEmployees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projektarbete_Avancerad_.NET.Models.TimeReport", "TimeReport")
                        .WithMany("TimeRepEmployees")
                        .HasForeignKey("TimeReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}