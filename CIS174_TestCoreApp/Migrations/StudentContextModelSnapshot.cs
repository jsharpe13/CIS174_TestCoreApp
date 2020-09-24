﻿// <auto-generated />
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIS174_TestCoreApp.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "Mark",
                            Grade = "A",
                            LastName = "Johnson"
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "Sam",
                            Grade = "B",
                            LastName = "Samson"
                        },
                        new
                        {
                            StudentId = 3,
                            FirstName = "Levi",
                            Grade = "C",
                            LastName = "Veinkmen"
                        },
                        new
                        {
                            StudentId = 4,
                            FirstName = "Nancy",
                            Grade = "D",
                            LastName = "Poole"
                        },
                        new
                        {
                            StudentId = 5,
                            FirstName = "Rebecca",
                            Grade = "F",
                            LastName = "Swanson"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
