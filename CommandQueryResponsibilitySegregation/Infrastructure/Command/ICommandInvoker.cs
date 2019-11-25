namespace CommandQueryResponsibilitySegregation.Infrastructure.Command
{
    public interface ICommandInvoker
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
