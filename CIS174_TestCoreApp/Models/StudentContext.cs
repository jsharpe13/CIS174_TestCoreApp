using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CIS174_TestCoreApp.Models
{
    public class StudentContext : IdentityDbContext<User>
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        protected StudentContext()
        {

        }

        public DbSet<Student>Students { get; set; }


        public DbSet<SportGame> SportGames { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<SportCountry> SportCountries { get; set; }
        public DbSet<SportCategory> SportCategories { get; set; }


        public DbSet<Ticketing> Ticketings { get; set; }
        public DbSet<TicketingPointValue> TicketingPointValues { get; set; }
        public DbSet<TicketingStatus> TicketingStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                FirstName = "Mark",
                LastName = "Johnson",
                Grade = "A"
            },
            new Student
            {
                StudentId = 2,
                FirstName = "Sam",
                LastName = "Samson",
                Grade = "B"
            },
            new Student
            {
                StudentId = 3,
                FirstName = "Levi",
                LastName = "Veinkmen",
                Grade = "C"
            },
            new Student
            {
                StudentId = 4,
                FirstName = "Nancy",
                LastName = "Poole",
                Grade = "D"
            },
            new Student
            {
                StudentId = 5,
                FirstName = "Rebecca",
                LastName = "Swanson",
                Grade = "F"
            }
            );

            //Olympics Sports Game
            modelBuilder.Entity<SportGame>().HasData(
                new SportGame { GameId = 1, Name = "Winter Olympics" },
                new SportGame { GameId = 2, Name = "Summer Olympics" },
                new SportGame { GameId = 3, Name = "Paralympics" },
                new SportGame { GameId = 4, Name = "Youth Olympic Games" }
            );
            modelBuilder.Entity<SportCategory>().HasData(
                new SportCategory { CategoryId = 1, Name = "Indoor" },
                new SportCategory { CategoryId = 2, Name = "Outdoor" }
            );
            modelBuilder.Entity<SportType>().HasData(
                new SportType { SportTypeId = 1, Name = "Curling", CategoryId = 1 },
                new SportType { SportTypeId = 2, Name = "Bobsleigh", CategoryId = 2 },
                new SportType { SportTypeId = 3, Name = "Diving", CategoryId = 1 },
                new SportType { SportTypeId = 4, Name = " Road Cycling", CategoryId = 2 },
                new SportType { SportTypeId = 5, Name = "Archery", CategoryId = 1 },
                new SportType { SportTypeId = 6, Name = "Canoe Sprint", CategoryId = 2 },
                new SportType { SportTypeId = 7, Name = "Breakdancing", CategoryId = 1 },
                new SportType { SportTypeId = 8, Name = "Skateboarding", CategoryId = 2 }
            );
            modelBuilder.Entity<SportCountry>().HasData(
                new SportCountry
                {
                    CountryId = 1,
                    Name = "Canada",
                    GameId = 1,
                    SportTypeId = 1,
                    LogoImage = "canadaflag.png"
                },
                new SportCountry
                {
                    CountryId = 2,
                    Name = "Sweden",
                    GameId = 1,
                    SportTypeId = 1,
                    LogoImage = "swedenflag.png"
                },
                new SportCountry
                {
                    CountryId = 3,
                    Name = "Great Britain",
                    GameId = 1,
                    SportTypeId = 1,
                    LogoImage = "britainflag.png"
                },
                new SportCountry
                {
                    CountryId = 4,
                    Name = "Jamaica",
                    GameId = 1,
                    SportTypeId = 2,
                    LogoImage = "jamaicaflag.png"
                },
                new SportCountry
                {
                    CountryId = 5,
                    Name = "Italy",
                    GameId = 1,
                    SportTypeId = 2,
                    LogoImage = "italyflag.png"
                },
                new SportCountry
                {
                    CountryId = 6,
                    Name = "Japan",
                    GameId = 1,
                    SportTypeId = 2,
                    LogoImage = "japanflag.png"
                },
                new SportCountry
                {
                    CountryId = 7,
                    Name = "Germany",
                    GameId = 2,
                    SportTypeId = 3,
                    LogoImage = "germanyflag.png"
                },
                new SportCountry
                {
                    CountryId = 8,
                    Name = "China",
                    GameId = 2,
                    SportTypeId = 3,
                    LogoImage = "chinaflag.png"
                },
                new SportCountry
                {
                    CountryId = 9,
                    Name = "Mexico",
                    GameId = 2,
                    SportTypeId = 3,
                    LogoImage = "mexicoflag.png"
                },
                new SportCountry
                {
                    CountryId = 10,
                    Name = "Brazil",
                    GameId = 2,
                    SportTypeId = 4,
                    LogoImage = "brazilflag.png"
                },
                new SportCountry
                {
                    CountryId = 11,
                    Name = "Netherlands",
                    GameId = 2,
                    SportTypeId = 4,
                    LogoImage = "netherlandsflag.png"
                },
                new SportCountry
                {
                    CountryId = 12,
                    Name = "USA",
                    GameId = 2,
                    SportTypeId = 4,
                    LogoImage = "usaflag.png"
                },
                new SportCountry
                {
                    CountryId = 13,
                    Name = "Thailand",
                    GameId = 3,
                    SportTypeId = 5,
                    LogoImage = "thailandflag.png"
                },
                new SportCountry
                {
                    CountryId = 14,
                    Name = "Uruguay",
                    GameId = 3,
                    SportTypeId = 5,
                    LogoImage = "uruguayflag.png"
                },
                new SportCountry
                {
                    CountryId = 15,
                    Name = "Ukraine",
                    GameId = 3,
                    SportTypeId = 5,
                    LogoImage = "ukraineflag.png"
                },
                new SportCountry
                {
                    CountryId = 16,
                    Name = "Austria",
                    GameId = 3,
                    SportTypeId = 6,
                    LogoImage = "austriaflag.png"
                },
                new SportCountry
                {
                    CountryId = 17,
                    Name = "Pakistan",
                    GameId = 3,
                    SportTypeId = 6,
                    LogoImage = "pakistanflag.png"
                },
                new SportCountry
                {
                    CountryId = 18,
                    Name = "Zimbabwe",
                    GameId = 3,
                    SportTypeId = 6,
                    LogoImage = "zimbabweflag.png"
                },
                new SportCountry
                {
                    CountryId = 19,
                    Name = "France",
                    GameId = 4,
                    SportTypeId = 7,
                    LogoImage = "franceflag.png"
                },
                new SportCountry
                {
                    CountryId = 20,
                    Name = "Cyprus",
                    GameId = 4,
                    SportTypeId = 7,
                    LogoImage = "cyprusflag.png"
                },
                new SportCountry
                {
                    CountryId = 21,
                    Name = "Russia",
                    GameId = 4,
                    SportTypeId = 7,
                    LogoImage = "russiaflag.png"
                },
                new SportCountry
                {
                    CountryId = 22,
                    Name = "Finland",
                    GameId = 4,
                    SportTypeId = 8,
                    LogoImage = "finlandflag.png"
                },
                new SportCountry
                {
                    CountryId = 23,
                    Name = "Slovakia",
                    GameId = 4,
                    SportTypeId = 8,
                    LogoImage = "slovakiaflag.png"
                },
                new SportCountry
                {
                    CountryId = 24,
                    Name = "Portugal",
                    GameId = 4,
                    SportTypeId = 8,
                    LogoImage = "portugalflag.png"
                }
            );

            //Ticketing System
            modelBuilder.Entity<TicketingPointValue>().HasData(
                new TicketingPointValue { pointValueId = "one", Name = "1" , orderNum=1},
                new TicketingPointValue { pointValueId = "two", Name = "2", orderNum = 2 },
                new TicketingPointValue { pointValueId = "three", Name = "3", orderNum = 3},
                new TicketingPointValue { pointValueId = "five", Name = "5", orderNum = 4},
                new TicketingPointValue { pointValueId = "eight", Name = "8", orderNum = 5},
                new TicketingPointValue { pointValueId = "thirteen", Name = "13", orderNum = 6},
                new TicketingPointValue { pointValueId = "twenty-one", Name = "21", orderNum = 7}
            );
            modelBuilder.Entity<TicketingStatus>().HasData(
                new TicketingStatus { StatusId="todo", Name="To Do"},
                new TicketingStatus { StatusId = "progress", Name="In Progress"},
                new TicketingStatus { StatusId= "quality", Name="Quality Assurance"},
                new TicketingStatus { StatusId="done", Name="Done"}
            );

            //(TEST ONLY)modelBuilder.Entity<Ticketing>().Property(t => t.StatusId).IsRequired();
            //(TEST ONLY)modelBuilder.ApplyConfiguration(new TestTicketingConfig());
            //(TEST ONLY)modelBuilder.Entity<Ticketing>().HasOne(t => t.Status).WithMany(s => s.Ticketings).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticketing>().HasData(
                new Ticketing 
                { 
                    SprintNumberId=1,
                    Name="File Switch",
                    Description="Switch project files",
                    pointValueId = "one",
                    StatusId = "done"
                },
                new Ticketing
                {
                    SprintNumberId = 2,
                    Name = "Look File Over",
                    Description = "Look File over for errors",
                    pointValueId = "three",
                    StatusId = "quality"
                },
                new Ticketing
                {
                    SprintNumberId = 3,
                    Name = "Swap Computer Systems",
                    Description = "Switch to completely new Computer system",
                    pointValueId = "eight",
                    StatusId = "progress"
                },
                new Ticketing
                {
                    SprintNumberId = 4,
                    Name = "Get Coffeee",
                    Description = "get coffee for group",
                    pointValueId = "one",
                    StatusId = "done"
                }
            );
        }
    }
}
