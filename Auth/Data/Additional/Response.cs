using Auth.Data.Enums;

namespace Auth.Data.Additional
{
    public class Response
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public Response(Status status, string message) 
        {
            Status = status;
            Message = message;
        }
        public Response()
        {
            Status = Status.Fail;
            Message = string.Empty;
        }
    }
}