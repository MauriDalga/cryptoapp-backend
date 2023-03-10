using BusinessLogicAdapter;
using Microsoft.AspNetCore.Mvc;
using Model.Read;
using Model.Write;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserLogicAdapter _userLogicAdapter;

        public UserController(UserLogicAdapter userLogicAdapter)
        {
            _userLogicAdapter = userLogicAdapter;
        }

        [AuthenticationFilter]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _userLogicAdapter.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
        }

        [AuthenticationFilter]
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                UserDetailInfoModel user = _userLogicAdapter.Get(id);

                return Ok(user);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] UserModel user)
        {
            try
            {
                UserDetailInfoModel userCreated = _userLogicAdapter.Create(user);
            
                return CreatedAtRoute("GetUserById", new { id = userCreated.Id }, userCreated);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
        }

        [AuthenticationFilter]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromRoute] int id, [FromBody] UserEditModel user)
        {
            try
            {
                _userLogicAdapter.Edit(id, user);

                return NoContent();
            }
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}