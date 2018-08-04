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
        private PactNetService _service = new PactNetService();

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            return Ok(new List<object> {
                _service.Get(0)
            });
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] object value)
        {
            return Ok(new {
                user_id = id,
                value = value
            });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
                return Ok();
                
            return BadRequest();
        }
    }
}
