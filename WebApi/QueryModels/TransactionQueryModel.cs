using Microsoft.AspNetCore.Mvc;

namespace WebApi.QueryModels
{
    public class TransactionQueryModel
    {
        [FromQuery(Name = "userid")]
        public string UserId { get; set; } = string.Empty;

        public bool NullParams()
        {
            return string.IsNullOrEmpty(UserId);
        }

        public IDictionary<string, string> GetParams()
        {
            IDictionary<string, string> parametros = new Dictionary<string, string>
            {
                { "userid", UserId }
            };

            return parametros;
        }
    }
}