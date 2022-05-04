using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Presentation.Persistence;
using Presentation.WebApi;
using System.IO;
using System.Threading.Tasks;

namespace Presentation.Test
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", true, true)
                   .AddEnvironmentVariables();


            _configuration = builder.Build();

            var connection = new SqliteConnection(_configuration.GetConnectionString("StructuralMetadataDatabase"));
            connection.Open();

            var services = new ServiceCollection().AddLogging(logging => logging.AddConsole());
            services.AddDbContext<StructuralMetadataDbContext>(options =>
                options.UseSqlite(connection));


            var environment = Mock.Of<IWebHostEnvironment>(w => w.ApplicationName == "Presentation.Application.Test" && w.EnvironmentName == "Development");

            var startup = new Startup(_configuration, environment);

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<StructuralMetadataDbContext>();
            context.Database.EnsureCreated();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }
    }
}
