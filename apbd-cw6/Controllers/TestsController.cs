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
            var test = Database.Tests.FirstOrDefault(x => x.Id == id);
            return Ok(test);
        }

        // GET api/tests?id=1
        // GET api/test/
        //POST api/tests{ "id": 4, "name": "Test4"}
        [HttpPost]
        public IActionResult Add(Test test)
        {
            Database.Tests.Add(test);
            return Created();
        }

        // 4. PUT: api/tests/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Test updatedTest)
        {
            var test = Database.Tests.FirstOrDefault(t => t.Id == id);
            if (test == null) return NotFound();

            test.Name = updatedTest.Name;
            return NoContent();
        }

        // 5. DELETE: api/tests/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var test = Database.Tests.FirstOrDefault(t => t.Id == id);
            if (test == null) return NotFound();

            Database.Tests.Remove(test);
            return NoContent();
        }

        // 6. GET: api/tests/search?name=Test1
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var matchingTests = Database.Tests.Where(t => t.Name == name).ToList();
            return Ok(matchingTests);
        }
    }
}