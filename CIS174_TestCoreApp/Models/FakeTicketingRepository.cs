using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;

namespace CIS174_TestCoreApp.Models
{
    public class FakeTicketingRepository : IRepository<Ticketing>
    {
        public void Delete(Ticketing entity)
        {
            throw new NotImplementedException();
        }

        public Ticketing Get(int sprintNumber)
        {
            throw new NotImplementedException();
        }

        public void Insert(Ticketing entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticketing> List(TicketingQueryOptions<Ticketing> options)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Ticketing entity)
        {
            throw new NotImplementedException();
        }
    }
}
