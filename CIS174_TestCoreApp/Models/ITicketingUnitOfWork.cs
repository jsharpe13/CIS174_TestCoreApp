using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
	public interface ITicketingUnitOfWork
	{
		public IRepository<Ticketing> Ticketings { get; }
		public IRepository<TicketingPointValue> TicketingPointValues { get; }
		public IRepository<TicketingStatus> TicketingStatuses { get; }

		public void Save();
	}
}
