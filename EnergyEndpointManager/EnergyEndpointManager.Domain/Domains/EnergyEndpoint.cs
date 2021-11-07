using EnergyEndpointManager.Domain.Enums;

namespace EnergyEndpointManager.Domain.Domains
{
    public class EnergyEndpoint
    {
        public EnergyEndpoint(string serialNumber, MeterModelEnum meterModelId, int meterNumber, string meterFirmwareVersion,
            SwitchStateEnum switchState)
        {
            SerialNumber = serialNumber;
            MeterModelId = meterModelId;
            MeterNumber = meterNumber;
            MeterFirmwareVersion = meterFirmwareVersion;
            SwitchState = switchState;
        }

        public string SerialNumber { get; set; }
        public MeterModelEnum MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchStateEnum SwitchState { get; set; }
    }
}