using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Controllers
{
    public class TicketingController : Controller
    {

        private ITicketingUnitOfWork _uow;

        public TicketingController(ITicketingUnitOfWork uow)
        {
            _uow = uow;
        }

        [Authorize]
        public IActionResult ticketIndex(string id)
        {

            var filters = new TicketingFilters(id);
            ViewBag.Filters = filters;

            var tpvOptions = new TicketingQueryOptions<TicketingPointValue>
            {
                OrderBy = t => t.orderNum
            };
            ViewBag.PointValues = _uow.TicketingPointValues.List(tpvOptions);

            var tsOptions = new TicketingQueryOptions<TicketingStatus>
            {
                OrderBy = t => t.StatusId
            };
            ViewBag.Statuses = _uow.TicketingStatuses.List(tsOptions);


            if (!filters.HasPointValue && !filters.HasStatus)
            {
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                };
                return View(_uow.Ticketings.List(tasks));
            }
            else if (filters.HasPointValue && filters.HasStatus)
            {
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.pointValueId == filters.pointValueId && t.StatusId == filters.StatusId)
                };
                return View(_uow.Ticketings.List(tasks));
            }
            else if (filters.HasPointValue)
            {

                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.pointValueId == filters.pointValueId)
                };
                return View(_uow.Ticketings.List(tasks));

            }
            else
            {
                var tasks = new TicketingQueryOptions<Ticketing>
                {
                    Includes = "pointValue, Status",
                    Where = (t => t.StatusId == filters.StatusId)
                };
                return View(_uow.Ticketings.List(tasks));
            }

            // return View(tasks);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ticketAdd()
        {
            //todo
            var tpvOptions = new TicketingQueryOptions<TicketingPointValue>
            {
                OrderBy = t => t.orderNum
            };
            ViewBag.PointValues = _uow.TicketingPointValues.List(tpvOptions);

            var tsOptions = new TicketingQueryOptions<TicketingStatus>
            {
                OrderBy = t => t.StatusId
            };
            ViewBag.Statuses = _uow.TicketingStatuses.List(tsOptions);

            return View();
        }

        [HttpPost]
        public IActionResult ticketAdd(Ticketing task)
        {
            if (ModelState.IsValid)
            {
                _uow.Ticketings.Insert(task);
                _uow.Ticketings.Save();
                return RedirectToAction("ticketIndex");
            }
            else
            {
                // todo
                var tpvOptions = new TicketingQueryOptions<TicketingPointValue>
                {
                    OrderBy = t => t.orderNum
                };
                ViewBag.PointValues = _uow.TicketingPointValues.List(tpvOptions);

                var tsOptions = new TicketingQueryOptions<TicketingStatus>
                {
                    OrderBy = t => t.StatusId
                };
                ViewBag.Statuses = _uow.TicketingStatuses.List(tsOptions);

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
                _uow.Ticketings.Delete(selected);

                _uow.Ticketings.Save();
                return RedirectToAction("ticketIndex", new { ID = id });
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = _uow.Ticketings.Get(selected.SprintNumberId);
                selected.StatusId = newStatusId;
                _uow.Ticketings.Update(selected);

                ///*
                try
                {
                    _uow.Ticketings.Save();
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
