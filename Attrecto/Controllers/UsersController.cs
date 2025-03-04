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

        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _repo.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repo.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User data)
        {
            var user = await _repo.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }

        // Adult users api/<UsersController>
        [HttpGet("adults")]
        public IEnumerable<User> AdultUsers()
        {
            return _repo.GetAdultUsersAsync();
        }
    }
}
