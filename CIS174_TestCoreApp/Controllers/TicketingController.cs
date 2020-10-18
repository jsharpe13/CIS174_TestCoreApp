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
            var filters = new TicketingFilters(id);
            ViewBag.Filters = filters;
            ViewBag.PointValues = context.TicketingPointValues.OrderBy(t => t.orderNum).ToList();
            ViewBag.Statuses = context.TicketingStatuses.ToList();

            IQueryable<Ticketing> query = context.Ticketings;
            if(filters.HasPointValue)
            {
                query = query.Where(t => t.pointValueId == filters.pointValueId);
            }
            if(filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
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
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Ticketings.Find(selected.SprintNumberId);
                selected.StatusId = newStatusId;
                context.Ticketings.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("ticketIndex", new { ID = id });
        }
    }
}
