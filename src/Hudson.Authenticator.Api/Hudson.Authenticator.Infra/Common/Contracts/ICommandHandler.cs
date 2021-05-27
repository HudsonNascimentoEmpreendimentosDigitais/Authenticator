namespace Hudson.Authenticator.Infra.Contracts
{
    public interface ICommandHandler<in T> where T : ICommandDefault
    {
        ICommandResult Handle(T command);
    }
}
