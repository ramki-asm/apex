using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using APEX.Common.Helpers;
using Common.Enums;
using Common.Models;

namespace HG_Laser.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public MachineLog MachineStatus { get; set; } = new();
        public ControlState CurrentState { get; set; }

        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand ResetCommand { get; }

        public DashboardViewModel()
        {
            StartCommand = new RelayCommand(_ => CurrentState = ControlState.Running);
            PauseCommand = new RelayCommand(_ => CurrentState = ControlState.Paused);
            StopCommand = new RelayCommand(_ => CurrentState = ControlState.Stopped);
            ResetCommand = new RelayCommand(_ => CurrentState = ControlState.Reset);
        }
    }

}
