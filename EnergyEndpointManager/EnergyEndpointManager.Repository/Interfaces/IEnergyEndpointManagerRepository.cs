using EnergyEndpointManager.Domain.Domains;
using System;
using System.Collections.Generic;

namespace EnergyEndpointManager.Repository.Interfaces
{
    public interface IEnergyEndpointManagerRepository
    {
        void Insert(EnergyEndpoint energyEndpoint);
        IList<EnergyEndpoint> GetAll();
        EnergyEndpoint Get(string serialNumber);
        void Edit(string serialNumber, EnergyEndpoint energyEndpointUpdated);
        void Delete(string serialNumber);
    }
}