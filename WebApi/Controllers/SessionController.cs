using Microsoft.AspNetCore.Mvc;
using BusinessLogicAdapter;
using Model.Write;

namespace WebApi.Controllers
{
    [Route("api/login")]
    public class SessionController : Controller
    {
        private readonly SessionLogicAdapter _sessionLogicAdapter;

        public SessionController(SessionLogicAdapter sessionLogicAdapter)
        {
            _sessionLogicAdapter = sessionLogicAdapter;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] SessionModel sessionModel)
        {
            try
            {
                var user = _sessionLogicAdapter.LogIn(sessionModel);

                return Ok(user);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}