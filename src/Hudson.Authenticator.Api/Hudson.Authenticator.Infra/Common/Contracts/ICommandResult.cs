namespace Hudson.Authenticator.Infra.Common.Contracts
{
    public interface ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
