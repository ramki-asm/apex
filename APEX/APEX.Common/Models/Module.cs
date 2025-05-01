using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.Common.Models
{
    public class Module
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<NavigationItem> MenuItems { get; set; } = new ObservableCollection<NavigationItem>();
    }
}
