using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult defaultRoute()
        {
            return View();
        }


        public IActionResult customRules(int page)
        {
            ViewBag.Page = page;
            return View();
        }

        [Route("/custom")]
        public IActionResult CustomAttribute()
        {
            return View();
        }
    }
}
