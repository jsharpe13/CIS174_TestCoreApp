using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Controllers
{
    public class SportsController : Controller
    {
        private StudentContext context { get; set; }

        public SportsController(StudentContext ctx)
        {
            context = ctx;
        }
        public ViewResult sportTest(int activeGame = 5, int activeCategory = 3)
        {
            var session = new SportCountrySession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveCategory(activeCategory);

            List<SportGame> Games = context.SportGames.ToList();
            List<SportCategory> Categories = context.SportCategories.ToList();
            Games.Insert(0, new SportGame { GameId = 5, Name = "All" });
            Categories.Insert(0, new SportCategory { CategoryId = 3, Name = "All" });

            ViewBag.ActiveGame = session.GetActiveGame();
            ViewBag.ActiveCategory = session.GetActiveCategory();
            ViewBag.Games = Games;
            ViewBag.Categories = Categories;

            //var countries = context.SportCountries.Include(c => c.Game).Include(m => m.SportType).Include(t => t.SportType.Category).OrderBy(g => g.Name).ToList();
            IQueryable<SportCountry> query = context.SportCountries;
            if(activeGame != 5)
            {
                query = query.Where(
                    t => t.Game.GameId == activeGame);
            }
            if(activeCategory != 3)
            {
                query = query.Where(
                    t => t.SportType.Category.CategoryId ==
                    activeCategory);
            }
            var countries = query.Include(r => r.SportType).Include(m => m.SportType).Include(t => t.SportType.Category).OrderBy(u => u.Name).ToList();
            return View(countries);
        }

        public ViewResult sportDetails(int id, int activeGame, int activeCategory)
        {
            var session = new SportCountrySession(HttpContext.Session);

            //ViewBag.ActiveGame = activeGame;
            //ViewBag.ActiveCategory = activeCategory;
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

        public RedirectToActionResult Add(int id)
        {
            var session = new SportCountrySession(HttpContext.Session);
            var countries = session.GetMyCountries();
            bool alreadyin = false;

            SportCountry country = context.SportCountries.Find(id);
            SportGame game = context.SportGames.Find(country.GameId);
            country.Game = game;
            SportType type = context.SportTypes.Find(country.SportTypeId);
            SportCategory category = context.SportCategories.Find(type.CategoryId);
            type.Category = category;
            country.SportType = type;

            foreach(var lc in countries)
            {
                if(lc.CountryId == id)
                {
                    alreadyin = true;
                }
            }
            if (alreadyin == false)
            {
                countries.Add(country);
                session.SetMyCountries(countries);
                TempData["message"] = $"{country.Name} added to your favorites";
            }
            else
            {
                TempData["message"] = $"{country.Name} is already in your favorites";
            }

            return RedirectToAction("sportTest",
                new
                {
                    activeGame = session.GetActiveGame(),
                    activeCategory = session.GetActiveCategory()
                });
        }
    }
}
