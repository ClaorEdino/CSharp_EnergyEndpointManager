using EnergyEndpointManager.Repository.Builders;
using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Services.Interfaces;
using EnergyEndpointManager.Services.Services;

namespace EnergyEndpointManager.Services.Builders
{
    public static class EnergyEndpointManagerServiceBuilder
    {
        public static IEnergyEndpointManagerService Build()
        {
            var repository = EnergyEndpointManagerRepositoryBuilder.Build();

            return new EnergyEndpointManagerService(repository);
        }

        public static IEnergyEndpointManagerService Build(IEnergyEndpointManagerRepository repository)
        {
            return new EnergyEndpointManagerService(repository);
        }
    }
}