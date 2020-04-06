using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    public class APIViewController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult GetTodos()
        {
            return View();
        }
    }
}