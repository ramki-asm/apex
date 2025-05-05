using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Helpers;

namespace UI.ViewModel
{
    public class HolderInfoViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public string SN { get; set; }
        public string Color { get; set; }
        public string MPN { get; set; }
        public string IMEI { get; set; }
        public string Artwork { get; set; }
    }
}
