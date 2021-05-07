using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Web.Api.DependencyInjection
{
    public static class DomainDependencyInjection
    {
        public static void AddDomainDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<ICheckoutDomainService, CheckoutDomainService>();
        }
    }
}
