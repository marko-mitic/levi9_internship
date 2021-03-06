using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore;

namespace OnlineMarks.Data.Models.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {

            var confBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = confBuilder.Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseMySQL(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationContext(builder.Options);
        }
    }
}
