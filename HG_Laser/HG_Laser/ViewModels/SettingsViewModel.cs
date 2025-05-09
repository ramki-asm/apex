using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms.Design;
using System.Windows.Input;
using APEX.Common.Helpers;
using APEX.Common.Models;
using APEX.Services.Interfaces;
using Common.Enums;
using Common.Models;
using UsbDeviceInfo = Common.Models.UsbDeviceInfo;

namespace UI.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISerialPortService _serialService;
        private readonly ITcpIpService _tcpIpService;
        private readonly IUsbService _usbService;

        public SettingsViewModel()
        {
                
        }
        public SettingsViewModel(
            ISerialPortService serialService,
            ITcpIpService tcpIpService,
            IUsbService usbService)
        {
            _serialService = serialService;
            _tcpIpService = tcpIpService;
            _usbService = usbService;

           // In your ViewModel constructor:
ConnectSerialCommand = new RelayCommand(_ => ConnectSerial());
ConnectTcpCommand = new RelayCommand(_ => ConnectTcp());
RefreshUsbCommand = new RelayCommand(_ => RefreshUsbDevices());

// Or using lambda syntax:
ConnectSerialCommand = new RelayCommand(param => ConnectSerial());

            // Load available ports/devices
            AvailablePorts = new ObservableCollection<string>(_serialService.GetAvailablePorts());
            BaudRates = new ObservableCollection<int> { 9600, 19200, 38400, 57600, 115200 };
            ParityOptions = new ObservableCollection<Parity> { Parity.None, Parity.Odd, Parity.Even };
            RefreshUsbDevices();
        }

        // Properties
        public ObservableCollection<string> AvailablePorts { get; }
        public string SelectedPort { get; set; }

        public ObservableCollection<int> BaudRates { get; }
        public int SelectedBaudRate { get; set; } = 9600;

        public ObservableCollection<Parity> ParityOptions { get; }
        public Parity SelectedParity { get; set; } = Parity.None;

        public string IpAddress { get; set; } = "192.168.1.1";
        public int Port { get; set; } = 502;

        public ObservableCollection<UsbDeviceInfo> UsbDevices { get; } = new();
        public UsbDeviceInfo SelectedUsbDevice { get; set; }

        public string ConnectionStatus { get; set; } = "Disconnected";
        public bool IsConnecting { get; set; }

        // Commands
        public ICommand ConnectSerialCommand { get; }
        public ICommand ConnectTcpCommand { get; }
        public ICommand RefreshUsbCommand { get; }

        private void ConnectSerial()
        {
            IsConnecting = true;
            ConnectionStatus = "Connecting...";

            //try
            //{
            //    var success = _serialService.Connect(SelectedPort, SelectedBaudRate, SelectedParity);
            //    ConnectionStatus = success ? "Connected" : "Connection failed";
            //}
            //catch (Exception ex)
            //{
            //    ConnectionStatus = $"Error: {ex.Message}";
            //}
            //finally
            //{
            //    IsConnecting = false;
            //}
        }

        private void ConnectTcp()
        {
            // Similar implementation for TCP connection
        }

        private void RefreshUsbDevices()
        {
            UsbDevices.Clear();
            foreach (var device in _usbService.GetAvailableDevices())
            {
                UsbDevices.Add(device);
            }
        }
    }
}