using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingStatus
    {
        [Key]
        public string StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Ticketing> Ticketings { get; set; }
    }
}
