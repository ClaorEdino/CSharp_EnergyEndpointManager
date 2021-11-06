using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Services.Interfaces;

namespace EnergyEndpointManager.Services.Services
{
    internal class EnergyEndpointManagerService : IEnergyEndpointManagerService
    {
        private readonly IEnergyEndpointManagerRepository repository;

        public EnergyEndpointManagerService(IEnergyEndpointManagerRepository repository)
        {
            this.repository = repository;
        }

        public void InsertEndpoint()
        {
            throw new System.NotImplementedException();
        }

        public void EditEndpoint()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEndpoint()
        {
            throw new System.NotImplementedException();
        }

        public void ListEndpoints()
        {
            throw new System.NotImplementedException();
        }

        public void FindEndpoint()
        {
            throw new System.NotImplementedException();
        }
    }
}