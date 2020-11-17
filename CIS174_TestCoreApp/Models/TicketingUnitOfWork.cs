using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class TicketingUnitOfWork : ITicketingUnitOfWork
    {
        private StudentContext context { get; set; }
        public TicketingUnitOfWork(StudentContext ctx) => context = ctx;

        private IRepository<Ticketing> TicketingData;
        public IRepository<Ticketing> Ticketings
        {
            get
            {
                if (TicketingData == null)
                    TicketingData = new Repository<Ticketing>(context);
                return TicketingData;
            }
        }

        private IRepository<TicketingPointValue> TicketingPointValueData;
        public IRepository<TicketingPointValue> TicketingPointValues
        {
            get
            {
                if (TicketingPointValueData == null)
                    TicketingPointValueData = new Repository<TicketingPointValue>(context);
                return TicketingPointValueData;
            }
        }

        private IRepository<TicketingStatus> TicketingStatusData;
        private Mock<StudentContext> mockdatabase;

        public IRepository<TicketingStatus> TicketingStatuses
        {
            get
            {
                if (TicketingStatusData == null)
                    TicketingStatusData = new Repository<TicketingStatus>(context);
                return TicketingStatusData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}

