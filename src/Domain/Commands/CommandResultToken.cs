namespace Domain.Commands
{
    public class CommandResultToken
    {
        public CommandResultToken(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Token { get; set; }
    }
}