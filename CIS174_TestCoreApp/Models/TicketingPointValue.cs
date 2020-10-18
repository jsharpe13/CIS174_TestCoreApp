using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingPointValue
    {
        [Key]
        public string pointValueId { get; set; }
        public string Name { get; set; }
        public int orderNum { get; set; }
    }
}
