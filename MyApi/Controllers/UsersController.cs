using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApi.Repositories;

namespace MyApi.Controllers
{
    using Microsoft.Extensions.Logging;
    using MyApi.Filters;

    [Route("[controller]")]
    [ExceptionHandler]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public UsersController(IUserRepository userRepository,
            ILogger<UsersController> logger)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get()
        => Json(userRepository.GetAll().Select(x => x.Name));

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            logger.LogInformation($"Fetch user by name: {name}");
            var user = userRepository.Get(name);
            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }
    }
}
