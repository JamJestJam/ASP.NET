using Aplikacja.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplikacja.Controllers
{
    public class ImageController : Controller
    {
        ICrudImageRepository repository;

        public ImageController(ICrudImageRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(model: repository.GetAll());
        }

        public IActionResult Show(int id)
        {
            return View(model: repository.GetFullImageInfo(id));
        }
    }
}
