using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ConsoleApp1
{
    class Server
    {
        public void Listen()
        {
            UdpClient listener = new UdpClient(1234);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, 123);
            while (true)
            {
                byte[] data = listener.Receive(ref serverEP);
                RaiseDataReceived(new ReceivedDataArgs(serverEP.Address, serverEP.Port, data));

                //raise event
            }
        }

        public delegate void DataReceived(object sender, ReceivedDataArgs args);
        public event DataReceived DataReceivedEvent;
        private void RaiseDataReceived(ReceivedDataArgs args)
        {
            if (DataReceivedEvent != null)
                DataReceivedEvent(this, args);
        }

    }

    public class ReceivedDataArgs
    {
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
        public byte[] ReceivedBytes;
        public ReceivedDataArgs(IPAddress ip, int port, byte[] data)
        {
            this.IpAddress = ip;
            this.Port = port;
            this.ReceivedBytes = data;
        }
    }
}
