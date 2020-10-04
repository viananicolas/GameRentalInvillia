using Newtonsoft.Json;

namespace GameRentalInvillia.Web.Services.JWT.Models
{
    public class ErrorMessage
    {
        public ErrorMessage(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; }
        public int StatusCode { get; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
