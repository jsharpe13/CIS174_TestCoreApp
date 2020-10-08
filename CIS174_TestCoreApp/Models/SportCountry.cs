using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class SportCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public SportGame Game { get; set; }
        public int SportTypeId { get; set; }
        public SportType SportType { get; set; }
        public string LogoImage { get; set; }
    }
}
