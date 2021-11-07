using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Services.Interfaces;
using EnergyEndpointManager.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EnergyEndpointManager.Services.Services
{
    internal class EnergyEndpointManagerService : IEnergyEndpointManagerService
    {
        private readonly IEnergyEndpointManagerRepository repository;

        public EnergyEndpointManagerService(IEnergyEndpointManagerRepository repository)
        {
            this.repository = repository;
        }

        public void InsertEndpoint(string serialNumber, int meterModelId, int meterNumber, string meterFirmwareVersion, int switchState)
        {
            repository.Insert(new EnergyEndpoint(serialNumber, (MeterModelEnum)meterModelId, meterNumber, meterFirmwareVersion, (SwitchStateEnum)switchState));
        }

        public void EditEndpoint(string serialNumber, int switchState)
        {
            var energyEndpoint = repository.Get(serialNumber);
            energyEndpoint.SwitchState = (SwitchStateEnum)switchState;

            repository.Edit(serialNumber, energyEndpoint);
        }

        public void DeleteEndpoint(string serialNumber)
        {
            repository.Delete(serialNumber);
        }

        public IList<EnergyEndpointViewModel> ListEndpoints()
        {
            var energyEndpoints = repository.GetAll();

            return energyEndpoints.Select(s => new EnergyEndpointViewModel(s)).ToList();
        }

        public EnergyEndpointViewModel FindEndpoint(string serialNumber)
        {
            var energyEndpoint = repository.Get(serialNumber);

            return new EnergyEndpointViewModel(energyEndpoint);
        }
    }
}