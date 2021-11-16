using Aplikacja.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Aplikacja.Controllers
{
    public class CommentController : Controller
    {
     
        public IActionResult Index()
        {
            throw new System.Exception();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddComment(Comment comment)
        {
            throw new System.Exception();
        }
    }
}
