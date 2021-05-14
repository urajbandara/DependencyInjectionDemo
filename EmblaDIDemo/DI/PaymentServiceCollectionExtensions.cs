using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDIAPI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PaymentServiceCollectionExtensions
    {
        public static IServiceCollection AddPayments(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.TryAddScoped<IPaymentService, OnlinePaymentService>();
            return services;
        }
    }
}
