using CommandQueryResponsibilitySegregation.Commands.Products;
using CommandQueryResponsibilitySegregation.Infrastructure.Command;
using CommandQueryResponsibilitySegregation.Infrastructure.DbContexts;
using CommandQueryResponsibilitySegregation.Infrastructure.Query;
using CommandQueryResponsibilitySegregation.Infrastructure.Repository;
using CommandQueryResponsibilitySegregation.Infrastructure.Initial;
using CommandQueryResponsibilitySegregation.Queries.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommandQueryResponsibilitySegregation.Infrastructure.DependencyInjection
{
    public static class RegisterDependencyInjection
    {
        private static ServiceProvider _servicesProvider = null;
        public static ServiceProvider ServicesProvider
        {
            get
            {
                if (_servicesProvider == null)
                {
                    //Register DI
                    _servicesProvider = CreateServices();
                    //Create DB
                    _servicesProvider.CreateDatabase();
                }
                
                return _servicesProvider;
            }
        }

        private static ServiceProvider CreateServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            services.AddSingleton<IConfiguration>(configuration);

            //DbContext Configurations
            services.AddDbContextConfigurations(configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped(typeof(ICommandRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IQueryRepository<>), typeof(Repository<>));

            services.AddScoped<ICommandInvoker, CommandInvoker>();
            services.AddScoped<IQueryInvoker, QueryInvoker>();

            ///services.AddScoped(typeof(ICommandHandler<>), typeof(ProductCommandHandlers));
            services.AddScoped(typeof(ICommandHandler<CreateProductCommand>), typeof(ProductCommandHandlers));

            ///services.AddScoped(typeof(IQueryHandler<,>), typeof(ProductQueryHandlers));
            services.AddScoped(typeof(IQueryHandler<GetProductByIdQuery, GetProductByIdResult>), typeof(ProductQueryHandlers));
            services.AddScoped(typeof(IQueryHandler<SearchProductQuery, SearchProductResult>), typeof(ProductQueryHandlers));

            return services.BuildServiceProvider();
        }

        private static void AddDbContextConfigurations(this IServiceCollection services, string connectionString)
        {
            //for Sqlite
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString,
                op =>
                {
                    op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                })
            );

            //for SqlServer
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            //        connectionString,
            //        opt => opt.UseRowNumberForPaging()
            //    )
            //);
        }
    }

    public static class ContextEngine<T>
    {
        public static T Resolve
        {
            get
            {
                return (T)RegisterDependencyInjection.ServicesProvider.GetService(typeof(T));
            }
        }
    }
}
