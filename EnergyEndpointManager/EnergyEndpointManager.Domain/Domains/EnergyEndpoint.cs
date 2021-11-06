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

        public string SerialNumber { get; private set; }
        public MeterModelEnum MeterModelId { get; private set; }
        public int MeterNumber { get; private set; }
        public string MeterFirmwareVersion { get; private set; }
        public SwitchStateEnum SwitchState { get; private set; }
    }
}