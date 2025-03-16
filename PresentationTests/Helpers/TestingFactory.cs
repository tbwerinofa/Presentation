using DataAccess.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PresentationTests.Helpers
{
    public class TestingFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.AddScoped(sp =>
                {
                    // Replace SQLite with the in memory provider for tests
                    return new DbContextOptionsBuilder<TaskDbContext>()
                                .UseInMemoryDatabase("TaskMgtInMemory", root)
                                .UseApplicationServiceProvider(sp)
                                .Options;
                });
            });

            return base.CreateHost(builder);
        }
    }
}
