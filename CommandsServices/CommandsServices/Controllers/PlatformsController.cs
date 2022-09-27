using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandsServices.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }


        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("--> InBound Post # Command Service");
            return Ok("InBound test of from Platforms Controller");
        }
    }
}
