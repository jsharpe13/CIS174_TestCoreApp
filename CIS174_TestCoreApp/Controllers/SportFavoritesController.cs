using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Controllers
{
    public class SportFavoritesController : Controller
    {
        private StudentContext context { get; set; }

        public SportFavoritesController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult sportFavoritesIndex()
        {
            var session = new SportCountrySession(HttpContext.Session);
            var countries = session.GetMyCountries();
            ViewBag.ActiveGame = session.GetActiveGame();
            ViewBag.ActiveCategory = session.GetActiveCategory();
            return View(countries);
        }

        public ViewResult sportFavoriteDetail(int id)
        {
            var session = new SportCountrySession(HttpContext.Session);

            ViewBag.ActiveGame = session.GetActiveGame();
            ViewBag.ActiveCategory = session.GetActiveCategory();
            SportCountry country = context.SportCountries.Find(id);
            SportGame game = context.SportGames.Find(country.GameId);
            country.Game = game;
            SportType type = context.SportTypes.Find(country.SportTypeId);
            SportCategory category = context.SportCategories.Find(type.CategoryId);
            type.Category = category;
            country.SportType = type;
            return View(country);
        }

        public RedirectToActionResult delete()
        {
            var session = new SportCountrySession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite Countries cleared";

            return RedirectToAction("sportTest", "Sports",
                new
                {
                    activeGame = session.GetActiveGame(),
                    activeCategory = session.GetActiveCategory()
                });
        }
    }
}
