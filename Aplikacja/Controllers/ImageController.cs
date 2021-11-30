using Aplikacja.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
