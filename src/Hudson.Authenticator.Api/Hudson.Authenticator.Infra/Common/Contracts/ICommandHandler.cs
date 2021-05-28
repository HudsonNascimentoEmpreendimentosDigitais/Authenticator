namespace Hudson.Authenticator.Infra.Common.Contracts
{
    public interface ICommandHandler<in T> where T : ICommandDefault
    {
        ICommandResult Handle(T command);
    }
}
