using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> List(TicketingQueryOptions<T> options);
        T Get(int sprintNumber);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
