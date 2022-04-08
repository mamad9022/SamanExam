using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Saman.Test.Backend.Domain.Repository;
using Saman.Test.Backend.Repository.Behaviors;
using Saman.Test.Backend.Repository.Implenetation;

namespace Saman.Test.Backend.Repository
{
    public static class DI
    {
        public static void UserRepositoryLayer(this IServiceCollection services, IConfiguration configuratio)
        {
            services.AddDbContext<SamanDbContext>(options =>
            {
                options.UseSqlServer(configuratio.GetConnectionString("SamanConnection"), sqlOptions =>
                {
                });

            }).AddLogging(builder => { builder.AddConsole(); });


            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<ITranscationRepository, TranscationRepository>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        }
    }
}
