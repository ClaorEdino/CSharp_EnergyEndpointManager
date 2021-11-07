using System;

namespace EnergyEndpointManager.Services.ViewModels
{
    public class BasicResponseViewModel
    {
        public BasicResponseViewModel(bool success)
        {
            Success = success;
        }

        public BasicResponseViewModel(bool success, string error) : this(success)
        {
            Error = error;
        }

        public bool Success { get; private set; }
        public string Error { get; private set; }
    }
}