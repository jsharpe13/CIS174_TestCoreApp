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
        // private StudentContext context { get; set; }
        private IRepository<Ticketing> data { get; set; }

        private IRepository<TicketingPointValue> tpv { get; set; }
        private IRepository<TicketingStatus> ts { get; set; }

        public TicketingController(IRepository<Ticketing> rep) => data = rep;

        //public TicketingController(StudentContext ctx)
        //{
        //    context = ctx;

        //    data = new TicketingRepository<Ticketing>(ctx);
        //}

        public IActionResult ticketIndex(string id)
        {
            // var dataAccess = new TicketingData(context);


            var filters = new TicketingFilters(id);
            ViewBag.Filters = filters;
            // ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
            var tpvOptions = new TicketingQueryOptions<TicketingPointValue>
            {
                OrderBy = t => t.orderNum
            };
            ViewBag.PointValues = tpv.List(tpvOptions);

            // ViewBag.Statuses = context.TicketingStatuses.ToList();


            if (!filters.HasPointValue && !filters.HasStatus)
            {
                //var tasks = dataAccess.GetTickets(new TicketingQueryOptions<Ticketing>
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    // Where = (t => t.pointValueId == filters.pointValueId && t.StatusId == filters.StatusId)
                };
                return View(data.List(tasks));
            }
            else if (filters.HasPointValue && filters.HasStatus)
            {
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.pointValueId == filters.pointValueId && t.StatusId == filters.StatusId)
                };
                return View(tasks);
            }
            else if (filters.HasPointValue)
            {

                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.pointValueId == filters.pointValueId)
                };
                return View(tasks);

            }
            else
            {
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.StatusId == filters.StatusId)
                };
                return View(tasks);
            }

            // return View(tasks);
        }

        [HttpGet]
        public IActionResult ticketAdd()
        {
            //todo
            //ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
            //ViewBag.Statuses = context.TicketingStatuses.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult ticketAdd(Ticketing task)
        {
            if (ModelState.IsValid)
            {
                // context.Ticketings.Add(task);
                data.Insert(task);
                // context.SaveChanges();
                data.Save();
                return RedirectToAction("ticketIndex");
            }
            else
            {
                // todo
                //ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
                //ViewBag.Statuses = context.TicketingStatuses.ToList();

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
            if (selected.StatusId == null)
            {
                //context.Ticketings.Remove(selected);
                data.Delete(selected);

                //context.SaveChanges();
                data.Save();
                return RedirectToAction("ticketIndex", new { ID = id });
            }
            else
            {
                string newStatusId = selected.StatusId;
                //selected = context.Ticketings.Find(selected.SprintNumberId);
                selected = data.Get(selected.SprintNumberId);
                selected.StatusId = newStatusId;
                //context.Ticketings.Update(selected);
                data.Update(selected);

                ///*
                try
                {
                    //context.SaveChanges();
                    data.Save();
                    return RedirectToAction("ticketIndex", new { ID = id });
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var dbValues = entry.GetDatabaseValues();
                    if (dbValues == null)
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

