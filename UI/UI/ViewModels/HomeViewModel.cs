using APEX.Common.Helpers;
using Common.Models;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<HolderModel> _holders;
        public ObservableCollection<HolderModel> Holders
        {
            get => _holders;
            set
            {
                _holders = value;
                OnPropertyChanged(nameof(Holders));
            }
        }

        public ProductionModeModel ProductionMode { get; set; }

        public HomeViewModel()
        {
            ProductionMode = new ProductionModeModel
            {
                ModeName = "PRODUCTION MODE",
                IsActive = true
            };

            Holders = new ObservableCollection<HolderModel>
            {
                new HolderModel { HolderName = "Holder 1" },
                new HolderModel { HolderName = "Holder 2" },
                new HolderModel { HolderName = "Holder 3" },
                new HolderModel { HolderName = "Holder 4" }
            };
        }
    }
}