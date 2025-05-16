using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace UI.ViewModels
{
    public class ProductionViewModel : BindableBase
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
