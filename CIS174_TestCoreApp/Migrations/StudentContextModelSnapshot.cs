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

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("SportCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Indoor"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Outdoor"
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportCountry", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportTypeId")
                        .HasColumnType("int");

                    b.HasKey("CountryId");

                    b.HasIndex("GameId");

                    b.HasIndex("SportTypeId");

                    b.ToTable("SportCountries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            GameId = 1,
                            LogoImage = "canadaflag.png",
                            Name = "Canada",
                            SportTypeId = 1
                        },
                        new
                        {
                            CountryId = 2,
                            GameId = 1,
                            LogoImage = "swedenflag.png",
                            Name = "Sweden",
                            SportTypeId = 1
                        },
                        new
                        {
                            CountryId = 3,
                            GameId = 1,
                            LogoImage = "britainflag.png",
                            Name = "Great Britain",
                            SportTypeId = 1
                        },
                        new
                        {
                            CountryId = 4,
                            GameId = 1,
                            LogoImage = "jamaicaflag.png",
                            Name = "Jamaica",
                            SportTypeId = 2
                        },
                        new
                        {
                            CountryId = 5,
                            GameId = 1,
                            LogoImage = "italyflag.png",
                            Name = "Italy",
                            SportTypeId = 2
                        },
                        new
                        {
                            CountryId = 6,
                            GameId = 1,
                            LogoImage = "japanflag.png",
                            Name = "Japan",
                            SportTypeId = 2
                        },
                        new
                        {
                            CountryId = 7,
                            GameId = 2,
                            LogoImage = "germanyflag.png",
                            Name = "Germany",
                            SportTypeId = 3
                        },
                        new
                        {
                            CountryId = 8,
                            GameId = 2,
                            LogoImage = "chinaflag.png",
                            Name = "China",
                            SportTypeId = 3
                        },
                        new
                        {
                            CountryId = 9,
                            GameId = 2,
                            LogoImage = "mexicoflag.png",
                            Name = "Mexico",
                            SportTypeId = 3
                        },
                        new
                        {
                            CountryId = 10,
                            GameId = 2,
                            LogoImage = "brazilflag.png",
                            Name = "Brazil",
                            SportTypeId = 4
                        },
                        new
                        {
                            CountryId = 11,
                            GameId = 2,
                            LogoImage = "netherlandsflag.png",
                            Name = "Netherlands",
                            SportTypeId = 4
                        },
                        new
                        {
                            CountryId = 12,
                            GameId = 2,
                            LogoImage = "usaflag.png",
                            Name = "USA",
                            SportTypeId = 4
                        },
                        new
                        {
                            CountryId = 13,
                            GameId = 3,
                            LogoImage = "thailandflag.png",
                            Name = "Thailand",
                            SportTypeId = 5
                        },
                        new
                        {
                            CountryId = 14,
                            GameId = 3,
                            LogoImage = "uruguayflag.png",
                            Name = "Uruguay",
                            SportTypeId = 5
                        },
                        new
                        {
                            CountryId = 15,
                            GameId = 3,
                            LogoImage = "ukraineflag.png",
                            Name = "Ukraine",
                            SportTypeId = 5
                        },
                        new
                        {
                            CountryId = 16,
                            GameId = 3,
                            LogoImage = "austriaflag.png",
                            Name = "Austria",
                            SportTypeId = 6
                        },
                        new
                        {
                            CountryId = 17,
                            GameId = 3,
                            LogoImage = "pakistanflag.png",
                            Name = "Pakistan",
                            SportTypeId = 6
                        },
                        new
                        {
                            CountryId = 18,
                            GameId = 3,
                            LogoImage = "zimbabweflag.png",
                            Name = "Zimbabwe",
                            SportTypeId = 6
                        },
                        new
                        {
                            CountryId = 19,
                            GameId = 4,
                            LogoImage = "franceflag.png",
                            Name = "France",
                            SportTypeId = 7
                        },
                        new
                        {
                            CountryId = 20,
                            GameId = 4,
                            LogoImage = "cyprusflag.png",
                            Name = "Cyprus",
                            SportTypeId = 7
                        },
                        new
                        {
                            CountryId = 21,
                            GameId = 4,
                            LogoImage = "russiaflag.png",
                            Name = "Russia",
                            SportTypeId = 7
                        },
                        new
                        {
                            CountryId = 22,
                            GameId = 4,
                            LogoImage = "finlandflag.png",
                            Name = "Finland",
                            SportTypeId = 8
                        },
                        new
                        {
                            CountryId = 23,
                            GameId = 4,
                            LogoImage = "slovakiaflag.png",
                            Name = "Slovakia",
                            SportTypeId = 8
                        },
                        new
                        {
                            CountryId = 24,
                            GameId = 4,
                            LogoImage = "portugalflag.png",
                            Name = "Portugal",
                            SportTypeId = 8
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportGame", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("SportGames");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Name = "Winter Olympics"
                        },
                        new
                        {
                            GameId = 2,
                            Name = "Summer Olympics"
                        },
                        new
                        {
                            GameId = 3,
                            Name = "Paralympics"
                        },
                        new
                        {
                            GameId = 4,
                            Name = "Youth Olympic Games"
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportType", b =>
                {
                    b.Property<int>("SportTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportTypeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SportTypes");

                    b.HasData(
                        new
                        {
                            SportTypeId = 1,
                            CategoryId = 1,
                            Name = "Curling"
                        },
                        new
                        {
                            SportTypeId = 2,
                            CategoryId = 2,
                            Name = "Bobsleigh"
                        },
                        new
                        {
                            SportTypeId = 3,
                            CategoryId = 1,
                            Name = "Diving"
                        },
                        new
                        {
                            SportTypeId = 4,
                            CategoryId = 2,
                            Name = " Road Cycling"
                        },
                        new
                        {
                            SportTypeId = 5,
                            CategoryId = 1,
                            Name = "Archery"
                        },
                        new
                        {
                            SportTypeId = 6,
                            CategoryId = 2,
                            Name = "Canoe Sprint"
                        },
                        new
                        {
                            SportTypeId = 7,
                            CategoryId = 1,
                            Name = "Breakdancing"
                        },
                        new
                        {
                            SportTypeId = 8,
                            CategoryId = 2,
                            Name = "Skateboarding"
                        });
                });

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

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Ticketing", b =>
                {
                    b.Property<int>("SprintNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("pointValueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SprintNumberId");

                    b.HasIndex("StatusId");

                    b.HasIndex("pointValueId");

                    b.ToTable("Ticketings");

                    b.HasData(
                        new
                        {
                            SprintNumberId = 1,
                            Description = "Switch project files",
                            Name = "File Switch",
                            StatusId = "done",
                            pointValueId = "one"
                        },
                        new
                        {
                            SprintNumberId = 2,
                            Description = "Look File over for errors",
                            Name = "Look File Over",
                            StatusId = "quality",
                            pointValueId = "three"
                        },
                        new
                        {
                            SprintNumberId = 3,
                            Description = "Switch to completely new Computer system",
                            Name = "Swap Computer Systems",
                            StatusId = "progress",
                            pointValueId = "eight"
                        },
                        new
                        {
                            SprintNumberId = 4,
                            Description = "get coffee for group",
                            Name = "Get Coffeee",
                            StatusId = "done",
                            pointValueId = "one"
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.TicketingPointValue", b =>
                {
                    b.Property<string>("pointValueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orderNum")
                        .HasColumnType("int");

                    b.HasKey("pointValueId");

                    b.ToTable("TicketingPointValues");

                    b.HasData(
                        new
                        {
                            pointValueId = "one",
                            Name = "1",
                            orderNum = 1
                        },
                        new
                        {
                            pointValueId = "two",
                            Name = "2",
                            orderNum = 2
                        },
                        new
                        {
                            pointValueId = "three",
                            Name = "3",
                            orderNum = 3
                        },
                        new
                        {
                            pointValueId = "five",
                            Name = "5",
                            orderNum = 4
                        },
                        new
                        {
                            pointValueId = "eight",
                            Name = "8",
                            orderNum = 5
                        },
                        new
                        {
                            pointValueId = "thirteen",
                            Name = "13",
                            orderNum = 6
                        },
                        new
                        {
                            pointValueId = "twenty-one",
                            Name = "21",
                            orderNum = 7
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.TicketingStatus", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("TicketingStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = "todo",
                            Name = "To Do"
                        },
                        new
                        {
                            StatusId = "progress",
                            Name = "In Progress"
                        },
                        new
                        {
                            StatusId = "quality",
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            StatusId = "done",
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportCountry", b =>
                {
                    b.HasOne("CIS174_TestCoreApp.Models.SportGame", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CIS174_TestCoreApp.Models.SportType", "SportType")
                        .WithMany()
                        .HasForeignKey("SportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.SportType", b =>
                {
                    b.HasOne("CIS174_TestCoreApp.Models.SportCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Ticketing", b =>
                {
                    b.HasOne("CIS174_TestCoreApp.Models.TicketingStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CIS174_TestCoreApp.Models.TicketingPointValue", "pointValue")
                        .WithMany()
                        .HasForeignKey("pointValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
