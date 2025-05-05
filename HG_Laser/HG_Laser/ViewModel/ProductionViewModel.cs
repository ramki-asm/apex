using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Helpers;
using Common.Models;

namespace UI.ViewModel
{
    public class ProductionViewModel : ViewModelBase
    {
        public ObservableCollection<HolderInfo> Holders { get; }

        public ProductionViewModel()
        {
            Holders = new ObservableCollection<HolderInfo>
        {
            new HolderInfo(),
            new HolderInfo(),
            new HolderInfo(),
            new HolderInfo()
        };
        }
    }

}
