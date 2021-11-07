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

        public BasicResponseViewModel InsertEndpoint(string serialNumber, int meterModelId, int meterNumber, string meterFirmwareVersion, int switchState)
        {
            repository.Insert(new EnergyEndpoint(serialNumber, (MeterModelEnum)meterModelId, meterNumber, meterFirmwareVersion, (SwitchStateEnum)switchState));

            return new BasicResponseViewModel(true);
        }

        public BasicResponseViewModel EditEndpoint(string serialNumber, int switchState)
        {
            var energyEndpoint = repository.Get(serialNumber);
            energyEndpoint.SwitchState = (SwitchStateEnum)switchState;

            repository.Edit(serialNumber, energyEndpoint);

            return new BasicResponseViewModel(true);
        }

        public BasicResponseViewModel DeleteEndpoint(string serialNumber)
        {
            repository.Delete(serialNumber);

            return new BasicResponseViewModel(true);
        }

        public GetAllEnergyEndpointResponseViewModel ListEndpoints()
        {
            var energyEndpoints = repository.GetAll();
            var energyEndpointsViewModel = energyEndpoints.Select(s => new EnergyEndpointViewModel(s)).ToList();

            return new GetAllEnergyEndpointResponseViewModel(true) { EnergyEndpoints = energyEndpointsViewModel };
        }

        public GetEnergyEndpointResponseViewModel FindEndpoint(string serialNumber)
        {
            var energyEndpoint = repository.Get(serialNumber);

            var energyEndpointViewModel = new EnergyEndpointViewModel(energyEndpoint);

            return new GetEnergyEndpointResponseViewModel(true) { EnergyEndpoint = energyEndpointViewModel };
        }
    }
}