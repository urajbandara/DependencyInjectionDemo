using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDIAPI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GuidServiceCollectionExtensions
    {
        public static IServiceCollection AddGuidServices(this IServiceCollection services)
        {
            services.AddSingleton<GuidService>();
            return services;
        }
    }
}
