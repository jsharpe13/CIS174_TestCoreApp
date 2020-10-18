using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingFilters
    {
        public TicketingFilters(string filterstring)
        {
            FilterString = filterstring ?? "all-all";
            string[] filters = FilterString.Split('-');
            pointValueId = filters[0];
            StatusId = filters[1];
        }
        public string FilterString { get; }
        public string pointValueId { get; }
        public string StatusId { get; }

        public bool HasPointValue => pointValueId.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";
    }
}
