using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingData
    {
        private StudentContext context { get; set; }

        public TicketingData(StudentContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Ticketing> queryData()
        {
            return context.Ticketings;
        }
        
        public IQueryable<Ticketing> filterTickets(IQueryable<Ticketing> query,
                                                    Expression<Func<Ticketing, bool>>where)
        {
            return query.Where(where);
        }
    }
}
