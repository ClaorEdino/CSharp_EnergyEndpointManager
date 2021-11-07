using System;

namespace EnergyEndpointManager.Services.ViewModels
{
    public class GetEnergyEndpointResponseViewModel : BasicResponseViewModel
    {
        public GetEnergyEndpointResponseViewModel(bool success) : base(success)
        {
        }

        public GetEnergyEndpointResponseViewModel(bool success, string error) : base(success, error)
        {
        }

        public EnergyEndpointViewModel EnergyEndpoint { get; internal set; }
    }
}