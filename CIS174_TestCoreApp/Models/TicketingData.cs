using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingData
    {
       // /*
        private StudentContext context { get; set; }
        public TicketingData(StudentContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Ticketing> GetTickets(TicketingQueryOptions<Ticketing> options)
        {
            IQueryable<Ticketing> query = context.Ticketings;
            foreach(string include in options.getIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
                query = query.OrderBy(options.OrderBy);

            return query.ToList();
        }
        //*/

        /*
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
                                                    Expression<Func<Ticketing, bool>> where)
        {
            return query.Where(where);
        }
        public IEnumerable<Ticketing>includeAll(IQueryable<Ticketing>query,
                                                Expression<Func<Ticketing, Object>>pointValue,
                                                Expression<Func<Ticketing, Object>>status,
                                                Expression<Func<Ticketing, Object>>orderBy)
        {
            return query.Include(pointValue).Include(status).OrderBy(orderBy).ToList();
        }
        */
    }
}
