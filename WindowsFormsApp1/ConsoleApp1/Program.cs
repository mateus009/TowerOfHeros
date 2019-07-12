using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0x18);
            Console.WriteLine(0x30);
            Console.ReadKey();

        }

    }
    class personagem
    {
        public int idade;
        public string nome;
        public int ola;
        public List<string> caras;
    }
        
        

    class HandleDataClass
    {
        public void SubscribeToEvent(Server server)
        {
            server.DataReceivedEvent += Server_DataReceivedEvent;
        }

        private void Server_DataReceivedEvent(object sender, ReceivedDataArgs args)
        {
            Console.WriteLine("Received message from [{0}:{1}]:\r\n{2}",
                args.IpAddress.ToString(), args.Port.ToString(),
                Encoding.ASCII.GetString(args.ReceivedBytes));
        }
    }


}
