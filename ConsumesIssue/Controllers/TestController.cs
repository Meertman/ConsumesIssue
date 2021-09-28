using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumesIssue.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Consumes("text/plain")]
        public IActionResult Upload() => Ok();

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult UploadWithInvalidContentType() => StatusCode(StatusCodes.Status415UnsupportedMediaType);
    }
}
