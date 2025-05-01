using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Services.Interfaces;
using APEX.UI.ViewModels.Shared;

namespace APEX.UI.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private readonly ILocalizationService _localizationService;

        public ReportsViewModel(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
    }
}
