namespace RND.IB.Autenticacao.Infra.Comum.Contracts
{
    public interface ICommandHandler<in T> where T : ICommandDefault
    {
        ICommandResult Handle(T command);
    }
}
