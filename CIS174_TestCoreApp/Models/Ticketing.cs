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
        [StringLength(30, ErrorMessage ="Name must be 30 characters or less.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter a description")]
        [DescriptionLength(ErrorMessage = "Description must be less than 150 characters")]
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
