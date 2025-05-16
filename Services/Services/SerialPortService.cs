using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using APEX.Services.Interfaces; // Add this namespace

namespace Services.Services
{
    public class SerialPortService : ISerialPortService
    {
        private SerialPort _serialPort;

        public event EventHandler<string> DataReceived;

        public bool IsConnected => _serialPort?.IsOpen ?? false;

        public void Connect(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate);
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, _serialPort.ReadExisting());
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        public void SendData(string data)
        {
            if (IsConnected)
            {
                _serialPort.Write(data);
            }
        }

      
        public IEnumerable<string> GetAvailablePorts()
        {
            throw new NotImplementedException();
        }
    }


    public class TcpIpService : ITcpIpService
    {
        public TcpIpService()
        {

        }
        private TcpClient _tcpClient;
        private NetworkStream _stream;

        public bool IsConnected => _tcpClient?.Connected ?? false;

   
           

        public void Disconnect()
        {
            _stream?.Close();
            _tcpClient?.Close();
        }

        bool ITcpIpService.Connect(string ipAddress, int port)
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect(ipAddress, port);
            _stream = _tcpClient.GetStream();
            return IsConnected;
        }
    }
}