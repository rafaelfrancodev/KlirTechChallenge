using Klir.TechChallenge.Infra.IoC.Application;
using Klir.TechChallenge.Infra.IoC.Domain;
using Klir.TechChallenge.Infra.IoC.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.IoC
{
    [ExcludeFromCodeCoverage]

    public class RootBootstrapper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstraper().ChildServiceRegister(services);
            new DomainBootstraper().ChildServiceRegister(services);
            new RepositoryBootstraper().ChildServiceRegister(services);
        }
    }
}
