using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Practic1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new ApplicationDbContext();

            dbContext.Database.EnsureCreated();

            dbContext.Database.ExecuteSqlRaw("SELECT * FROM Materials m");

            Console.WriteLine();
            Console.WriteLine($"Provider DB Name: {dbContext.Database.ProviderName}");
            Console.WriteLine();
        }
    }

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<ApplicationDbContext>().Build();

            var connectionString = configuration.GetConnectionString("BuildingCompanyDB");

            //var connectionStringBuilder = new SqlConnectionStringBuilder
            //{
            //    ["Server"] = "Shindd",
            //    ["Database"] = "BuildingCompanyDB",
            //    ["Trusted_Connection"] = true
            //};
            //Console.WriteLine(connectionStringBuilder.ConnectionString);

            optionsBuilder.UseSqlServer(connectionString).EnableDetailedErrors().
                EnableSensitiveDataLogging().LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }
    }

}