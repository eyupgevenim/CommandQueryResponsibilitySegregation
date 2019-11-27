using CommandQueryResponsibilitySegregation.Infrastructure.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Initial
{
    public static class DatabaseInitializerExtension
    {
        public static void CreateDatabase(this ServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var dbName = configuration.GetConnectionString("DefaultConnection");
            var filePath = dbName.Replace("Filename=", "");
            if (File.Exists(filePath))
                File.Delete(filePath);

            var context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();
        }
    }
}
