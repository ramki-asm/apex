using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace UI.ViewModels
{
    public class HolderInfoViewModel : BindableBase
    {
        private string? _title;
        private string? _sn;
        private string? _color;
        private string? _mpn;
        private string? _imei;
        private string? _artwork;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public string? SN
        {
            get => _sn;
            set => SetProperty(ref _sn, value);
        }
        public string? Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
        public string? MPN
        {
            get => _mpn;
            set => SetProperty(ref _mpn, value);
        }
        public string? IMEI
        {
            get => _imei;
            set => SetProperty(ref _imei, value);
        }
        public string? Artwork
        {
            get => _artwork;
            set => SetProperty(ref _artwork, value);
        }
    }
     
}
