using System;
using System.Collections.Generic;

namespace EnergyEndpointManager.Services.ViewModels
{
    public class GetAllEnergyEndpointResponseViewModel : BasicResponseViewModel
    {
        public GetAllEnergyEndpointResponseViewModel(bool success) : base(success)
        {
        }

        public GetAllEnergyEndpointResponseViewModel(bool success, string error) : base(success, error)
        {
        }

        public List<EnergyEndpointViewModel> EnergyEndpoints { get; internal set; }
    }
}
