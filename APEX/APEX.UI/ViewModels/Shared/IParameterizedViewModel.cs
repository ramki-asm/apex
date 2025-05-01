using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.UI.ViewModels.Shared
{
    public interface IParameterizedViewModel
    {
        void Initialize(object parameter);
    }
}
