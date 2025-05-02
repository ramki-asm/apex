using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.Common.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type ViewModelType { get; set; }
        public bool IsEnabled { get; set; } = true;
        public int Order { get; set; }
        public string RequiredPermission { get; set; }
    }

}
