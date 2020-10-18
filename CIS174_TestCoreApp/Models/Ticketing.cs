using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Ticketing
    {
        [Key]
        public int SprintNumberId { get; set; }


        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please select a point value")]
        public string pointValueId { get; set; }
        public TicketingPointValue pointValue { get; set; }


        [Required(ErrorMessage = "Please select a status")]
        public string StatusId { get; set; }
        public TicketingStatus Status { get; set; }

        public bool Done =>
            StatusId?.ToLower() == "done";
    }
}
