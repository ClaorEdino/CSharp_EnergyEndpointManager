using EnergyEndpointManager.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace EnergyEndpointManager.Services.Interfaces
{
    public interface IEnergyEndpointManagerService
    {
        BasicResponseViewModel InsertEndpoint(string serialNumber, int meterModelId, int meterNumber, string meterFirmwareVersion, int switchState);
        BasicResponseViewModel EditEndpoint(string serialNumber, int switchState);
        BasicResponseViewModel DeleteEndpoint(string serialNumber);
        GetAllEnergyEndpointResponseViewModel ListEndpoints();
        GetEnergyEndpointResponseViewModel FindEndpoint(string serialNumber);
    }
}