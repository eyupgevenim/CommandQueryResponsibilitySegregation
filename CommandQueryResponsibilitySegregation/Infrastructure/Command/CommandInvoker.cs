using System;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Command
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly ICommandHandler<ICommand> _commandHandler;

        public CommandInvoker(ICommandHandler<ICommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _commandHandler.Execute(command);
        }
    }
}
