using Newtonsoft.Json;

namespace OnlineMuhasebeServer.WebApi.Middleware
{
    public class ErrorResult : ErrorStatusCode
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set;}
    }

    public class ValidationErrorDetails : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
