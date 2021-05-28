using Hudson.Authenticator.Infra.Common.Contracts;

namespace Hudson.Authenticator.Domain.Commands.Output
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
