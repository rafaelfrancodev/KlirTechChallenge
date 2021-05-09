using Klir.TechChallenge.Application.CheckoutAppService;
using Klir.TechChallenge.Application.Interfaces;
using Klir.TechChallenge.Application.ProductAppService;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.IoC.Application
{
    [ExcludeFromCodeCoverage]
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<ICheckoutAppService, CheckoutAppService>();
        }
    }
}
