﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace UI.ViewModels
{
    public class UserViewModel:BindableBase
    {
        public UserViewModel()
        {
            var obj = new LoginWithUserAccessViewModel();
        }
    }
}
