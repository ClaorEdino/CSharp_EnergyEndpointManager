using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Repository.Repositories;

namespace EnergyEndpointManager.Repository.Builders
{
    public static class EnergyEndpointManagerRepositoryBuilder
    {
        public static IEnergyEndpointManagerRepository Build()
        {
            return new EnergyEndpointManagerRepository();
        }
    }
}