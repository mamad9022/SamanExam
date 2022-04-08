using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saman.Test.Backend.Application.System;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build();
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                #region Database

                var mediator = services.GetRequiredService<IMediator>();
                await mediator.Send(new SampleSeedDataCommand(), CancellationToken.None);

                #endregion Database

                await host.RunAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
