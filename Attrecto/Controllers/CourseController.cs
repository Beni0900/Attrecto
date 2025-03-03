using Attrecto.Data;
using Attrecto.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Attrecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository _repo;

        public CourseController()
        {
            _repo = new CourseRepository();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _repo.GetById(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(data);

            return NoContent();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            var result = _repo.Update(id, data);

            return result == null ? NotFound(): NoContent();
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repo.Delete(id);

            return result ? NoContent() : NotFound();
        }
    }
}
