using Microsoft.AspNetCore.Mvc;

namespace PalomaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Helloooooo";
        }
    }
}