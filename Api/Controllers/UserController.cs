using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PactNet.Library;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _service = new UserService();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return Ok(new {
                user_id = 52,
                value = value
            });
        }
    }
}
