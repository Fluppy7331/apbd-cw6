using apbd_cw6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace apbd_cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var tests = Database.Tests;
            return Ok(tests);
        }
        // GET api/tests?id=1
        // GET api/test/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var test = Database.Tests.FirstOrDefault(x=>x.Id == id);
            return Ok(test);
        }
        // GET api/tests?id=1
        // GET api/test/1
        
        
        //POST api/tests{ "id": 4, "name": "Test4"}
        [HttpPost]
        public IActionResult Add(Test test)
        {
            Database.Tests.Add(test);
            return Created();
        }
    }
}
