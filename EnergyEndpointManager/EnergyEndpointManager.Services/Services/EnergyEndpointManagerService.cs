using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Services.Interfaces;
using EnergyEndpointManager.Services.ViewModels;
using System;
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
            try
            {
                repository.Insert(new EnergyEndpoint(serialNumber, (MeterModelEnum)meterModelId, meterNumber, meterFirmwareVersion, (SwitchStateEnum)switchState));
            }
            catch(Exception exc)
            {
                return new BasicResponseViewModel(false, exc.ToString());
            }

            return new BasicResponseViewModel(true);
        }

        public BasicResponseViewModel EditEndpoint(string serialNumber, int switchState)
        {
            try
            {
                var energyEndpoint = repository.Get(serialNumber);
                energyEndpoint.SwitchState = (SwitchStateEnum)switchState;

                repository.Edit(serialNumber, energyEndpoint);
            }
            catch(Exception exc)
            {
                return new BasicResponseViewModel(false, exc.ToString());
            }

            return new BasicResponseViewModel(true);
        }

        public BasicResponseViewModel DeleteEndpoint(string serialNumber)
        {
            try
            {
                repository.Delete(serialNumber);
            }
            catch(Exception exc)
            {
                return new BasicResponseViewModel(false, exc.ToString());
            }

            return new BasicResponseViewModel(true);
        }

        public GetAllEnergyEndpointResponseViewModel ListEndpoints()
        {
            IList<EnergyEndpointViewModel> energyEndpointsViewModel;

            try
            {
                var energyEndpoints = repository.GetAll();
                energyEndpointsViewModel = energyEndpoints.Select(s => new EnergyEndpointViewModel(s)).ToList();
            }
            catch(Exception exc)
            {
                return new GetAllEnergyEndpointResponseViewModel(false, exc.ToString());
            }

            return new GetAllEnergyEndpointResponseViewModel(true) { EnergyEndpoints = energyEndpointsViewModel };
        }

        public GetEnergyEndpointResponseViewModel FindEndpoint(string serialNumber)
        {
            EnergyEndpointViewModel energyEndpointViewModel;

            try
            {
                var energyEndpoint = repository.Get(serialNumber);

                energyEndpointViewModel = new EnergyEndpointViewModel(energyEndpoint);
            }
            catch(Exception exc)
            {
                return new GetEnergyEndpointResponseViewModel(false, exc.ToString());
            }

            return new GetEnergyEndpointResponseViewModel(true) { EnergyEndpoint = energyEndpointViewModel };
        }
    }
}