using CommandQueryResponsibilitySegregation.Commands.Products;
using CommandQueryResponsibilitySegregation.Infrastructure.DependencyInjection;
using CommandQueryResponsibilitySegregation.Infrastructure.Command;
using CommandQueryResponsibilitySegregation.Infrastructure.Query;
using CommandQueryResponsibilitySegregation.Queries.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CommandQueryResponsibilitySegregation
{
    class Program
    {
        static void Main(string[] args)
        {
            //get services provider
            var servicesProvider = RegisterDependencyInjection.ServicesProvider;

            Console.WriteLine($"======= ICommandInvoker =======");
            var commandInvoker = servicesProvider.GetRequiredService<ICommandInvoker>();
            commandInvoker.Execute(new CreateProductCommand
            {
                Id = 1,
                Name = $"Test Product 1",
                Description = $"Test Product 1 Description",
                Stock = 10,
                Price = 12.5M
            });
            commandInvoker.Execute(new CreateProductCommand
            {
                Id = 2,
                Name = $"Test Product 2",
                Description = $"Test Product 2 Description",
                Stock = 4,
                Price = 56.00M
            });
            commandInvoker.Execute(new CreateProductCommand
            {
                Id = 3,
                Name = $"Test Product 3",
                Description = $"Test Product 3 Description",
                Stock = 50,
                Price = 7.65M
            });

            Console.WriteLine($"======= IQueryInvoker GetProductById =======");
            var queryInvoker = servicesProvider.GetRequiredService<IQueryInvoker>();
            var product = queryInvoker.Query<GetProductByIdQuery,GetProductByIdResult>(new GetProductByIdQuery { Id = 2 });
            if (product != null)
                Console.WriteLine($"\t product - Id:{product.Id} - Name:{product.Name} - Description:{product.Description} - Stock:{product.Stock} - Price:{product.Price}");

            Console.WriteLine($"======= IQueryInvoker SearchProduct =======");
            var products = queryInvoker.Query<SearchProductQuery,SearchProductResult>(new SearchProductQuery { Name = "Pro" });
            if (products != null && products.Products.Any())
            {
                foreach (var item in products.Products)
                    Console.WriteLine($"\t item - Id:{item.Id} - Name:{item.Name} - Description:{item.Description} - Stock:{item.Stock} - Price:{item.Price}");
            }

            Console.WriteLine($"======= END... =======");
            Console.ReadKey();
        }
    }
}
