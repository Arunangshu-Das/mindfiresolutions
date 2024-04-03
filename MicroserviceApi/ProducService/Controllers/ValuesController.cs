using Microsoft.AspNetCore.Mvc;
using ProducService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PracticeContext _context;
        public ValuesController(PracticeContext context) 
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _context.Students.Select(x => x.Name).ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _context.Students.Where(s=>s.StudentId==id).FirstOrDefault();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
