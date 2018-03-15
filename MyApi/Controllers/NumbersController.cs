using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("[controller]")]
    public class NumbersController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var numbers = new List<int> { 1, 2 };
            return Json(numbers);
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            return Content(number.ToString());
        }

        [HttpGet("{number}")]
        public IActionResult GetNumber(int number)
        {
            return Content(number.ToString());
        }

        [HttpPost]
        public IActionResult Post(int number)
        {
            return Created($"/numbers/{number}", null);
        }

        [HttpDelete]
        public IActionResult Delete(int number)
        {
            return NoContent();
        }
    }
}
