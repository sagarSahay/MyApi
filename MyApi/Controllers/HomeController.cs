using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    using Microsoft.Extensions.Options;
    using Settings;

    [Route("[controller]")]
    public class HomeController : Controller
    {
        private AppSettings settings;

        public HomeController(IOptions<AppSettings> settings)
        {
            this.settings = settings.Value;
        }

        [HttpGet]
        public IActionResult Get()
            => Content($"Welcome to the Accountant API! [{settings.AppEnv}]");

    }
}