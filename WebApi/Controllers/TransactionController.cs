using BusinessLogicAdapter;
using Microsoft.AspNetCore.Mvc;
using Model.Read;
using Model.Write;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [AuthenticationFilter]
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        private readonly TransactionLogicAdapter _transactionLogicAdapter;

        public TransactionController(TransactionLogicAdapter transactionLogicAdapter)
        {
            _transactionLogicAdapter = transactionLogicAdapter;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] TransactionModel transaction)
        {
            try
            {
                _transactionLogicAdapter.Create(transaction);
                return NoContent();
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}