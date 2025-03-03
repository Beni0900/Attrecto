using Attrecto.Data;
using Attrecto.Respositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Attrecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _repo;

        public UsersController()
        {
            _repo = new UserRepository();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _repo.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            var user = _repo.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repo.Delete(id);

            return result ? NoContent() : NotFound();
        }

        // Adult users api/<UsersController>
        [HttpGet("adults")]
        public IEnumerable<User> AdultUsers()
        {
            return _repo.GetAdultUsers();
        }
    }
}
