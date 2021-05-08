using Klir.TechChallenge.Domain.Interfaces.Repositories;
using Klir.TechChallenge.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.IoC.Repository
{
    [ExcludeFromCodeCoverage]
    internal class RepositoryBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
