using CommandQueryResponsibilitySegregation.Commands.Products;
using CommandQueryResponsibilitySegregation.Infrastructure.Command;
using CommandQueryResponsibilitySegregation.Infrastructure.Initial;
using CommandQueryResponsibilitySegregation.Infrastructure.Query;
using CommandQueryResponsibilitySegregation.Queries.Products;
using System;
using System.Linq;

namespace CommandQueryResponsibilitySegregation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register DI
            var servicesProvider = RegisterDependencyInjection.ServicesProvider;
            //Create DB
            servicesProvider.CreateDatabase();

            Console.WriteLine($"======= ICommandHandler =======");
            var commandHandlerCreateProduct = (ICommandHandler<CreateProductCommand>)servicesProvider.GetService(typeof(ICommandHandler<CreateProductCommand>));
            commandHandlerCreateProduct.Execute(new CreateProductCommand
            {
                Id = 1,
                Name = $"Test Product 1",
                Description = $"Test Product 1 Description",
                Stock = 10,
                Price = 12.5M
            });
            commandHandlerCreateProduct.Execute(new CreateProductCommand
            {
                Id = 2,
                Name = $"Test Product 2",
                Description = $"Test Product 2 Description",
                Stock = 4,
                Price = 56.00M
            });
            commandHandlerCreateProduct.Execute(new CreateProductCommand
            {
                Id = 3,
                Name = $"Test Product 3",
                Description = $"Test Product 3 Description",
                Stock = 50,
                Price = 7.65M
            });

            Console.WriteLine($"======= IQueryHandler GetProductById =======");
            var queryHandlerProductById = (IQueryHandler<GetProductByIdQuery, GetProductByIdResult>)servicesProvider
                .GetService(typeof(IQueryHandler<GetProductByIdQuery, GetProductByIdResult>));
            var product = queryHandlerProductById.Query(new GetProductByIdQuery { Id = 2 });
            if (product != null)
                Console.WriteLine($"\t product - Id:{product.Id} - Name:{product.Name} - Description:{product.Description} - Stock:{product.Stock} - Price:{product.Price}");

            Console.WriteLine($"======= IQueryHandler SearchProduct =======");
            var queryHandlerSearchProduct = (IQueryHandler<SearchProductQuery, SearchProductResult>)servicesProvider
                .GetService(typeof(IQueryHandler<SearchProductQuery, SearchProductResult>));
            var products = queryHandlerSearchProduct.Query(new SearchProductQuery { Name = "Pro" });
            if(products != null && products.Products.Any())
            {
                foreach (var item in products.Products)
                    Console.WriteLine($"\t item - Id:{item.Id} - Name:{item.Name} - Description:{item.Description} - Stock:{item.Stock} - Price:{item.Price}");
            }

            Console.WriteLine($"======= END... =======");
            Console.ReadKey();
        }
    }
}
