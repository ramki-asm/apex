using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
 
using Common.Models;

namespace UI.ViewModels
{
    class AlarmViewModel: BindableBase

    {
        private ObservableCollection<Alarm> alarm;

        public ObservableCollection<Alarm> Alarm
        {
            get => alarm;
            set=> SetProperty(ref alarm, value);
          
        }
         
        public AlarmViewModel()
        {
            
            Alarm = new ObservableCollection<Alarm>
            {
                new Alarm { Serial = 1, Module = "Solder", Content = "PLC Stopped", Time = DateTime.Now.AddMinutes(-5) }

            };
        }

         
    }
}
