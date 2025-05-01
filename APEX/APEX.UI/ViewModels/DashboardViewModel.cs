using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Services.Interfaces;
using APEX.UI.ViewModels.Shared;

namespace APEX.UI.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly ILocalizationService _localizationService;

        public DashboardViewModel(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
    }
}
