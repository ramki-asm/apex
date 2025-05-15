using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace APEX.Services.Interfaces
{
    public interface ISerialPortService
    {
        bool IsConnected { get; }
        void Connect(string portName, int baudRate);
        void Disconnect();
        IEnumerable<string> GetAvailablePorts();

        event EventHandler<string> DataReceived;

    }

    // ITcpIpService.cs
    public interface ITcpIpService
    {
        bool Connect(string ipAddress, int port);
        void Disconnect();
    }

    // IUsbService.cs
    public interface IUsbService
    {
        ObservableCollection<UsbDeviceInfo> GetAvailableDevices();
        bool Connect(string deviceId);
        void Disconnect();
    }

   
}
