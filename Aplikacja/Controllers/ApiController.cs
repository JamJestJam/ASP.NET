using Aplikacja.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace Aplikacja.Controllers
{
    [ApiController]
    [Route(template: "/api/v1/Users")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiController : ControllerBase
    {
        private ICrudUserRepository rep;

        public ApiController(ICrudUserRepository repository)
        {
            this.rep = repository;
        }

        [HttpGet]
        [Route(template: "{id}")]
        public ActionResult<User> Get(int? id)
        {
            if (id == null) return BadRequest();

            var tmp = rep.GetAll()
                .FirstOrDefault(a => a.UserID == id);

            if (tmp == null)
                return NotFound();
            else return tmp;
        }

        [HttpDelete]
        [MyException]
        [Route(template: "{id}")]
        public ActionResult<User> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            //var tmp = rep.remove((int) id);
            var tmp = rep.GetAll().FirstOrDefault(a => a.UserID == id);
            if (tmp == null)
                return NotFound();
            else
                return Ok();
        }

        [HttpPost]

        public ActionResult<User> Add(User user)
        {
            if (ModelState.IsValid)
                return rep.Add(user);
            else return BadRequest();
        }

        [HttpPut]
        [Route(template: "{id}")]
        public ActionResult<User> Put(int? id, User user)
        {
            if (id == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                user.UserID = (int)id;
                return rep.Update(user);
            }
            else return BadRequest();
        }

    }
}
