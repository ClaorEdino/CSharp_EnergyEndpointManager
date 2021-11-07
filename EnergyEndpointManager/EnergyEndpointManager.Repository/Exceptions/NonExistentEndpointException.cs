using System;

namespace EnergyEndpointManager.Repository.Exceptions
{
    public class NonExistentEndpointException : Exception
    {
        private readonly string serialNumber;

        public NonExistentEndpointException(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public override string ToString()
        {
            return string.Format("An endpoint with the serial number {0} was not found.", serialNumber);
        }
    }
}