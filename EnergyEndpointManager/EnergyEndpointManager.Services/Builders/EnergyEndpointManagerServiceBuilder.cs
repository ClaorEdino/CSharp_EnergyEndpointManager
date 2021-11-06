using EnergyEndpointManager.Repository.Builders;
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
    }
}