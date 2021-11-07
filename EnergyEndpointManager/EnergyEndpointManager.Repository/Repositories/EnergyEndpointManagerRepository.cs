using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public EnergyEndpoint Get(string serialNumber)
        {
            return dataTable.Where(s => s.SerialNumber == serialNumber).FirstOrDefault();
        }

        public void Edit(string serialNumber, EnergyEndpoint energyEndpointUpdated)
        {
            var energyEndpoint = Get(serialNumber);
            energyEndpoint.MeterModelId = energyEndpointUpdated.MeterModelId;
            energyEndpoint.MeterNumber = energyEndpointUpdated.MeterNumber;
            energyEndpoint.MeterFirmwareVersion = energyEndpointUpdated.MeterFirmwareVersion;
            energyEndpoint.SwitchState = energyEndpointUpdated.SwitchState;
        }

        public void Delete(string serialNumber)
        {
            var endpoint = Get(serialNumber);
            dataTable.Remove(endpoint);
        }
    }
}