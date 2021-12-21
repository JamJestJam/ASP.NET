using Aplikacja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aplikacja.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private ICrudUserRepository repository;

        public LoginController(ICrudUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(int page = 0)
        {
            if (page <= 0)
                page = 0;
            var entities = repository.GetPage(page);
            if (entities.Count <= 0)
            {
                page = 0;
                entities = repository.GetPage(page);
            }
            ViewData["page"] = page;

            return View("index", model: entities);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                repository.Add(user);
                return (this.Index());
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult Remove(int id)
        {
            repository.remove(id);
            return Index();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(model: repository.Find(id));
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Update(user);
                return Index();
                //ViewData["page"] = 0;
                //return View("Index", model: repository.GetAll());
            }
            else
            {
                return View("Update");
            }
        }
    }
}
