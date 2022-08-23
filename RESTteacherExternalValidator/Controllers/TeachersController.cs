using Microsoft.AspNetCore.Mvc;
using RESTteacherExternalValidator.Managers;
using RESTteacherExternalValidator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTteacherExternalValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private TeachersManager manager = new TeachersManager();

        // GET: api/<TeachersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // 204 No Content: Det er nemmere for JS at modtage en tom liste end ingen liste, så undlad 204
        public IEnumerable<Teacher> Get()
        {
            return manager.GetAll();
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher? teacher = manager.GetById(id);
            if (teacher == null) return NotFound("No such id: " + id);
            return Ok(teacher);
        }

        // POST api/<TeachersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Teacher> Post([FromBody] Teacher value)
        {
            try
            {
                Teacher newTeacher = manager.Add(value);
                return Ok(newTeacher);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }

        // PUT api/<TeachersController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Teacher> Delete(int id)
        {
            Teacher? teacher = manager.Delete(id);
            if (teacher == null) return NotFound("No such id: " + id);
            return Ok(teacher);
        }
    }
}
