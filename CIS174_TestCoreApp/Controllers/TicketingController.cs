using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Controllers
{
    public class TicketingController : Controller
    {
        private StudentContext context { get; set; }

        public TicketingController(StudentContext ctx)
        {
            context = ctx;
        }

        public IActionResult ticketIndex(string id)
        {
            var dataAccess = new TicketingData(context);

            var filters = new TicketingFilters(id);
            ViewBag.Filters = filters;
            ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
            ViewBag.Statuses = context.TicketingStatuses.ToList();

            //IQueryable<Ticketing> query = context.Ticketings;
            var query = dataAccess.queryData();
            if(filters.HasPointValue)
            {
                //query = query.Where(t => t.pointValueId == filters.pointValueId);
                query = dataAccess.filterTickets(query, t => t.pointValueId == filters.pointValueId);
            }
            if(filters.HasStatus)
            {
                //query = query.Where(t => t.StatusId == filters.StatusId);
                query = dataAccess.filterTickets(query, t => t.StatusId == filters.StatusId);
            }
            var tasks = query.Include(t => t.pointValue).Include(t => t.Status).OrderBy(t => t.SprintNumberId).ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult ticketAdd()
        {
            ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
            ViewBag.Statuses = context.TicketingStatuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ticketAdd(Ticketing task)
        {
            if(ModelState.IsValid)
            {
                context.Ticketings.Add(task);
                context.SaveChanges();
                return RedirectToAction("ticketIndex");
            }
            else
            {
                ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
                ViewBag.Statuses = context.TicketingStatuses.ToList();
                ModelState.AddModelError("", "There are errors in the form.");
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult ticketFilter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("ticketIndex", new { ID = id });
        }

        [HttpPost]
        public IActionResult ticketEdit([FromRoute] string id, Ticketing selected)
        {
            if(selected.StatusId == null)
            {
                context.Ticketings.Remove(selected);

                context.SaveChanges();
                return RedirectToAction("ticketIndex", new { ID = id });
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Ticketings.Find(selected.SprintNumberId);
                selected.StatusId = newStatusId;
                context.Ticketings.Update(selected);

                ///*
                try
                {
                    context.SaveChanges();
                    return RedirectToAction("ticketIndex", new { ID = id });
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var dbValues = entry.GetDatabaseValues();
                    if(dbValues == null)
                    {
                        ModelState.AddModelError("", "Unable to save- "
                            + "this ticket was deleted by another user.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save - "
                            + "this book was modified by another user. "
                            + "The current database values are displayed "
                            + "below. Please edit as needed and click Save, "
                            + "or click Cancel");

                        var dbTicket = (Ticketing)dbValues.ToObject();

                        if (dbTicket.Name != selected.Name)
                            ModelState.AddModelError("Name",
                                $"Current db value: {dbTicket.Name}");
                        if (dbTicket.Description != selected.Description)
                            ModelState.AddModelError("Description",
                                $"Current db value: {dbTicket.Description}");
                        if (dbTicket.pointValueId != selected.pointValueId)
                            ModelState.AddModelError("pointValueId",
                                $"Current db value: {dbTicket.pointValueId}");
                        if (dbTicket.StatusId != selected.StatusId)
                            ModelState.AddModelError("StatusId",
                                $"Current db value: {dbTicket.StatusId}");
                    }
                    return RedirectToAction("ticketIndex", new { ID = id }); 
                }
                //*/
                
            }
            //context.SaveChanges();

            //return RedirectToAction("ticketIndex", new { ID = id });
        }
    }
}
