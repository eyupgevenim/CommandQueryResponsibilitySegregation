using CommandQueryResponsibilitySegregation.Infrastructure.DependencyInjection;
using System;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Command
{

    public class CommandInvoker : ICommandInvoker
    {
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var commandHandler = ContextEngine<ICommandHandler<TCommand>>.Resolve;
            commandHandler.Execute(command);
        }
    }

}
