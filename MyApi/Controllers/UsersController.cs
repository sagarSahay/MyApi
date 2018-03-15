using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApi.Repositories;

namespace MyApi.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public IActionResult Get()
        => Json(userRepository.GetAll().Select(x => x.Name));

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var user = userRepository.Get(name);
            if(user == null)
            {
                return NotFound();
            }

            return Json(user);
        }
    }
}
