using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class SportCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
