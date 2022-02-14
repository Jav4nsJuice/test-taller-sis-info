using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private static readonly string[] Teams = new[]
        {
            "Backend", "Frontend", "Mobile"
        };

        private static readonly string[] Names = new[]
        {
            "Tiara", "Camila", "Kevin","Carolina", "Alvaro", "Diego","Javier", "Angy", "Omar", "Sebastian", "Victor", "Miguel","Andres","Lucero"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            var rng = new Random();
            int i = 0;
            return Enumerable.Range(1, Names.Length).Select(index => new Test
            {
                //Date = DateTime.Now.AddDays(index),
                Name = Names[i++],
                Age = rng.Next(18, 25),
                Team = Teams[rng.Next(Teams.Length)]
            })
            .ToArray();
        }

    }
}
