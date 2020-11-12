﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected StudentContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(StudentContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> List(TicketingQueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.getIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
            {
                query = query.OrderBy(options.OrderBy);
            }
            return query.ToList();
        }

        public virtual T Get(int id) => dbset.Find(id);

        public virtual T Get(TicketingQueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.getIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            return query.FirstOrDefault();
        }

        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Save() => context.SaveChanges();
    }

}