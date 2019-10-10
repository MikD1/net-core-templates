using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.WebApi.Controllers
{
    [Route("api/about")]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Get()
        {
            string verison = GetType().Assembly.GetName().Version.ToString();
            return Ok($"Microservice - v{verison}");
        }
    }
}
