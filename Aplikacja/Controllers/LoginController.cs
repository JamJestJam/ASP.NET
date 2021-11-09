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
        //static private List<User> Users = new List<User>()
        //{
        //    new User()
        //    {
        //        UserID=0,
        //        Login="marek1",
        //        Password="zaq1@WSX",
        //        Email="marek1@cos.com"
        //    },
        //    new User()
        //    {
        //        UserID=1,
        //        Login="marek2",
        //        Password="zaq1@WSX",
        //        Email="marek2@cos.com"
        //    },
        //    new User()
        //    {
        //        UserID=2,
        //        Login="marek3",
        //        Password="zaq1@WSX",
        //        Email="marek3@cos.com"
        //    },
        //};

        //static private int Top = 3;

        private IDB repository;

        public LoginController(IDB repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(model: repository.Users.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Register(User user)
        {

            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    Users.Add(user);
            //    return View("Index", Users);
            //}
            //else
            //{
            //    return View("Add");
            //}
        }

        public IActionResult Remove(int id)
        {
            throw new NotImplementedException();
            //Users.Remove(Users.First(a => a.UserID == id));
            //return View("Index", model: Users);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
            //return View(model: Users.First(a => a.UserID == id));
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    Users[Users.IndexOf(Users.First(a => a.UserID == user.UserID))] = user;
            //    return View("Index", Users);
            //}
            //else
            //{
            //    return View("Add");
            //}
            throw new NotImplementedException();
        }
    }
}
