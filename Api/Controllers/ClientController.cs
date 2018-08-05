using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PactNet.Library;

namespace Api.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase {
    private PactNetClient _client = new PactNetClient("https://localhost:5001");

    [HttpGet]
    public ActionResult<IEnumerable<object>> Get () {
      return Ok (new List<object> {
        _client.Get(0)
      });
    }
  }
}