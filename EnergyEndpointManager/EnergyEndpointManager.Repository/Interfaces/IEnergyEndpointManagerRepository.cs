using EnergyEndpointManager.Domain.Domains;
using System;
using System.Collections.Generic;

namespace EnergyEndpointManager.Repository.Interfaces
{
    public interface IEnergyEndpointManagerRepository
    {
        void Insert(EnergyEndpoint energyEndpoint);
        IList<EnergyEndpoint> GetAll();
    }
}