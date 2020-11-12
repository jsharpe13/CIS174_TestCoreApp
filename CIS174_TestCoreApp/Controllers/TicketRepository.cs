using CIS174_TestCoreApp.Models;

namespace CIS174_TestCoreApp.Controllers
{
    internal class TicketRepository<T>
    {
        private StudentContext ctx;

        public TicketRepository(StudentContext ctx)
        {
            this.ctx = ctx;
        }
    }
}