using EnergyEndpointManager.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace EnergyEndpointManager.Services.Interfaces
{
    public interface IEnergyEndpointManagerService
    {
        void InsertEndpoint(string serialNumber, int meterModelId, int meterNumber, string meterFirmwareVersion, int switchState);
        void EditEndpoint(string serialNumber, int switchState);
        void DeleteEndpoint(string serialNumber);
        IList<EnergyEndpointViewModel> ListEndpoints();
        EnergyEndpointViewModel FindEndpoint(string serialNumber);
    }
}