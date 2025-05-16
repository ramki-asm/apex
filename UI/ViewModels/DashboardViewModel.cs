using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
 
using APEX.Common.Enums;
using Common.Models;
using Common.Enums;

namespace UI.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        public MachineLog MachineStatus { get; set; } = new();
        public ControlState CurrentState { get; set; }

        public DelegateCommand<Object> StartCommand { get; }
        public DelegateCommand<Object> PauseCommand { get; }
        public DelegateCommand<Object> StopCommand { get; }
        public DelegateCommand<Object> ResetCommand { get; }

        public DashboardViewModel()
        {
            StartCommand = new DelegateCommand<Object>(_ => CurrentState = ControlState.Running);
            PauseCommand = new DelegateCommand<Object>(_ => CurrentState = ControlState.Paused);
            StopCommand = new DelegateCommand<Object>(_ => CurrentState = ControlState.Stopped);
            ResetCommand = new DelegateCommand<Object>(_ => CurrentState = ControlState.Reset);
        }
    }

}
