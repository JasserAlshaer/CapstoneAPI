using System.Net;

namespace CapstoneAPI
{
    public class FriendlyException : Exception
    {
        public int ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public FriendlyException(string message, int errorCode = 1000, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public FriendlyException(string message, Exception innerException, int errorCode = 1000, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public object ToErrorResponse()
        {
            return new
            {
                message = this.Message,
                code = this.ErrorCode,
                status = (int)this.StatusCode,
                timestamp = DateTime.UtcNow
            };
        }
    }
}
