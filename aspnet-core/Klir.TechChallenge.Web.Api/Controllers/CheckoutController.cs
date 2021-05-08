using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("api/v1/checkout")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Post()
        {
            var result = new[] { "oi" };
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Delete()
        {
            var result = new[] { "oi" };
            return Ok(result);
        }
    }
}