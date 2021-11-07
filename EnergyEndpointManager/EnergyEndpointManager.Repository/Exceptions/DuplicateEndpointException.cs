using System;

namespace EnergyEndpointManager.Repository.Exceptions
{
    public class DuplicateEndpointException : Exception
    {
        private readonly string serialNumber;

        public DuplicateEndpointException(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public override string ToString()
        {
            return String.Format("And endpoint with the serial number {0} already exists.", serialNumber);
        }
    }
}