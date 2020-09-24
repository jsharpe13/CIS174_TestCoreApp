using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIS174_TestCoreApp.Models;

namespace CIS174_TestCoreApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Input(AccessLevel access)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Details", access);
            }
            else
            {
                return View(access);
            }
        }

        public IActionResult Details(AccessLevel access)
        {
            ViewBag.Access = access.Level;
            List<Student> students = context.Students.OrderBy(m => m.LastName).ToList();
            return View(students);
        }
    }
}
