using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using System;

namespace EnergyEndpointManager.Services.ViewModels
{
    public class EnergyEndpointViewModel
    {
        public EnergyEndpointViewModel(EnergyEndpoint energyEndpoint)
        {
            SerialNumber = energyEndpoint.SerialNumber;
            MeterNumber = energyEndpoint.MeterNumber;
            MeterFirmwareVersion = energyEndpoint.MeterFirmwareVersion;
            InitializeMeterModelId(energyEndpoint);
            InitializeSwitchState(energyEndpoint);
        }

        public string SerialNumber { get; set; }
        public string MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public string SwitchState { get; set; }

        private void InitializeMeterModelId(EnergyEndpoint energyEndpoint)
        {
            switch (energyEndpoint.MeterModelId)
            {
                case MeterModelEnum.NSX1P2W:
                    MeterModelId = "NSX1P2W";
                    break;
                case MeterModelEnum.NSX1P3W:
                    MeterModelId = "NSX1P3W";
                    break;
                case MeterModelEnum.NSX2P3W:
                    MeterModelId = "NSX2P3W";
                    break;
                case MeterModelEnum.NSX3P4W:
                    MeterModelId = "NSX3P4W";
                    break;
            }
        }

        private void InitializeSwitchState(EnergyEndpoint energyEndpoint)
        {
            switch (energyEndpoint.SwitchState)
            {
                case SwitchStateEnum.Disconnected:
                    SwitchState = "Disconnected";
                    break;
                case SwitchStateEnum.Connected:
                    SwitchState = "Connected";
                    break;
                case SwitchStateEnum.Armed:
                    SwitchState = "Armed";
                    break;
            }
        }
    }
}