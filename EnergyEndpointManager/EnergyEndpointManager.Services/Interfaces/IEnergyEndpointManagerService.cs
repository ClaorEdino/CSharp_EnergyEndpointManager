using System;

namespace EnergyEndpointManager.Services.Interfaces
{
    public interface IEnergyEndpointManagerService
    {
        void InsertEndpoint();
        void EditEndpoint();
        void DeleteEndpoint();
        void ListEndpoints();
        void FindEndpoint();
    }
}