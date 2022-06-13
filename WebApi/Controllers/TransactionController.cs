using BusinessLogicAdapter;
using Microsoft.AspNetCore.Mvc;
using Model.Write;
using WebApi.Filters;
using WebApi.QueryModels;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery] TransactionQueryModel transactionQueryModel)
        {
            try
            {
                if (!transactionQueryModel.NullParams())
                {
                    var queryParams = transactionQueryModel.GetParams();
                    var transactions = _transactionLogicAdapter.GetCollection(queryParams);

                    return Ok(transactions);
                }

                return BadRequest("Missing required query params.");
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