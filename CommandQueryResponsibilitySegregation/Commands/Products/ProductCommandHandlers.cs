using CommandQueryResponsibilitySegregation.Infrastructure.Command;
using CommandQueryResponsibilitySegregation.Infrastructure.Entities;
using CommandQueryResponsibilitySegregation.Infrastructure.Repository;
using System;

namespace CommandQueryResponsibilitySegregation.Commands.Products
{
    public class ProductCommandHandlers 
        : ICommandHandler<CreateProductCommand>
    {
        private readonly ICommandRepository<Product> _commandProductRepository;

        public ProductCommandHandlers(ICommandRepository<Product> commandProductRepository)
        {
            _commandProductRepository = commandProductRepository;
        }

        public void Execute(CreateProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var product = new Product
            {
                //Id = command.Id,//pk identity(1,1)
                Name = command.Name,
                Description = command.Description,
                Stock = command.Stock,
                Price = command.Price
            };

            _commandProductRepository.Add(product);
            _commandProductRepository.Save();
        }
    }
}
