using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using APEX.Common.Helpers;
using Common.Models;

namespace UI.ViewModels
{
    class AlarmViewModel: ViewModelBase

    {
        private ObservableCollection<Alarm> alarm;

        public ObservableCollection<Alarm> Alarm
        {
            get => alarm;
            set
            {
                alarm = value;
                OnPropertyChanged(nameof(Alarm));
            }
        }
         
        public AlarmViewModel()
        {
            // Sample data
            Alarm = new ObservableCollection<Alarm>
            {
                new Alarm { Serial = 1, Module = "Solder", Content = "PLC Stopped", Time = DateTime.Now.AddMinutes(-5) }

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
