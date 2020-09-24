using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class AccessLevel
    {
        [Required(ErrorMessage = "Please enter your access level.")]
        [Range(1, 10, ErrorMessage = "the number must be between 1 and 10.")]
        public int? Level { get; set; }
    }
}
