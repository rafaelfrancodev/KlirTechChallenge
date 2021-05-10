using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.IoC.Domain
{
    [ExcludeFromCodeCoverage]
    internal class DomainBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddSingleton<ICheckoutDomainService, CheckoutDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddSingleton<IProductPromotionDomainService, ProductPromotionDomainService>();
        }
    }
}
