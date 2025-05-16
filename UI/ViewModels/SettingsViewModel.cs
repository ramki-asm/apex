using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Input;
using APEX.Common.Models;
using APEX.Services.Interfaces;
using Common.Enums;
using Common.Models;
using log4net;
using UsbDeviceInfo = Common.Models.UsbDeviceInfo;

namespace UI.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));

        private readonly ISerialPortService _serialService;
        private readonly ITcpIpService _tcpIpService;
        private readonly IUsbService _usbService;

        public SettingsViewModel()
        {
            LoginWithUserAccessViewModel obj = new LoginWithUserAccessViewModel();
        }
        public SettingsViewModel(
            ISerialPortService serialService,
            ITcpIpService tcpIpService,
            IUsbService usbService)
        {
            _serialService = serialService;
            _tcpIpService = tcpIpService;
            _usbService = usbService;

           
ConnectSerialCommand = new DelegateCommand<Object>(_ => ConnectSerial());
ConnectTcpCommand = new DelegateCommand<Object>(_ => ConnectTcp());
RefreshUsbCommand = new DelegateCommand<Object>(_ => RefreshUsbDevices());

 
ConnectSerialCommand = new DelegateCommand<Object>(param => ConnectSerial());

         
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
        public DelegateCommand<Object> ConnectSerialCommand { get; }
        public DelegateCommand<Object> ConnectTcpCommand { get; }
        public DelegateCommand<Object> RefreshUsbCommand { get; }

        private void ConnectSerial()
        {
            IsConnecting = true;
            ConnectionStatus = "Connecting...";

            try
            {
                if (SelectedPort != null && SelectedBaudRate != 0)
                {
                    var success = true;// _serialService.Connect(SelectedPort, SelectedBaudRate);
                    ConnectionStatus = success ? "Connected" : "Connection failed";
                }
            }
            catch (Exception ex)
            {
                ConnectionStatus = $"Error: {ex.Message}";
            }
            finally
            {
                IsConnecting = false;
            }
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