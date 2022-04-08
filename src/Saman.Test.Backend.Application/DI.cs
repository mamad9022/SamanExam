using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saman.Test.Backend.Application.Common;
using System.Reflection;

namespace Saman.Test.Backend.Application
{
    public static class DI
    {
        public static void UseApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
