using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    internal class TestTicketingConfig : IEntityTypeConfiguration<Ticketing>
    {
        public void Configure(EntityTypeBuilder<Ticketing> entity)
        {
            entity.HasKey(t => t.SprintNumberId);

            entity.Property(t => t.Name).IsRequired().HasMaxLength(30);
            entity.Property(t => t.Description).IsRequired().HasMaxLength(150);
            entity.Property(t => t.pointValueId).IsRequired();
            entity.Property(t => t.StatusId).IsRequired();

            entity.HasData(
                new Ticketing {SprintNumberId = 1, Name = "File Switch", Description = "Switch project files", pointValueId = "one", StatusId = "done" },
                new Ticketing {SprintNumberId = 2, Name = "Look File Over", Description = "Look File over for errors", pointValueId = "three", StatusId = "quality" }
            );
        }
    }
}
