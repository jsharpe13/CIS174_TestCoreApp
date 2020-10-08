using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class SportType
    {
        [Key]
        public int SportTypeId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public SportCategory Category { get; set; }
    }
}
