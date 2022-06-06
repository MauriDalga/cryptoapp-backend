using BusinessLogicAdapter;
using Microsoft.AspNetCore.Mvc;
using Model.Read;
using Model.Write;

[assembly: ApiController]
namespace WebApi.Controllers
{
    [Route("users")]
    //[AuthenticationFilter]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class UserController : Controller
    {
        private readonly UserLogicAdapter _userLogicAdapter;

        public UserController(UserLogicAdapter userLogicAdapter)
        {
            _userLogicAdapter = userLogicAdapter;
        }

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
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(UserModel user)
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromRoute] int id, [FromBody] UserModel user)
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
        
        [Route("{id}/coin-accounts")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAccountsFromUser([FromRoute] int id)
        {
            try
            {
                var coinAccounts = _userLogicAdapter.GetAccountsFromUser(id);

                return Ok(coinAccounts);
            }
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
        }
    }
}