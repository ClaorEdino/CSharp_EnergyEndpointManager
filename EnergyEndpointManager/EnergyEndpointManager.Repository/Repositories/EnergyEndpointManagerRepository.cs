using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Interfaces;
using System.Collections.Generic;

namespace EnergyEndpointManager.Repository.Repositories
{
    internal class EnergyEndpointManagerRepository : IEnergyEndpointManagerRepository
    {
        private readonly IList<EnergyEndpoint> dataTable;

        public EnergyEndpointManagerRepository()
        {
            dataTable = new List<EnergyEndpoint>();
        }

        public void Insert(EnergyEndpoint energyEndpoint)
        {
            dataTable.Add(energyEndpoint);
        }

        public IList<EnergyEndpoint> GetAll()
        {
            return dataTable;
        }
    }
}