using Aplikacja.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Controllers
{
    public class LoginController : Controller
    {
        static private List<User> Users = new List<User>();

        public IActionResult Index()
        {
            return View(model: Users);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                Users.Add(user);
                return View("Index", Users);
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult Remove(int id)
        {

            return View();
        }
    }
}
