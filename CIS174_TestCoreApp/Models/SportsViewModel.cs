using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class SportsViewModel
    {
        public List<SportCountry> sportCountry { get; set; }
        public int activeGame { get; set; } = 5;
        public int activeCategory { get; set; } = 3;
    }
}
