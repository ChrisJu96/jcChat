using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chat
{
    class Server
    {
        private IPAddress serverIP;
        private int serverPort;
        public bool isRunning = false;

        public Server(string ipaddress, string port)
        {
            this.serverIP = IPAddress.Parse(ipaddress);
            this.serverPort = int.Parse(port);
            // Start the server
            Start();
        }
        void Start()
        {
            isRunning = true;

            Console.WriteLine("Starte Server ...");

            TcpListener Server = new TcpListener(serverIP,serverPort);
            Server.Start();
            Console.WriteLine("Horche auf Port" + serverPort + "  .");

            Console.WriteLine("Warte auf Verbindung ...");
            TcpClient Client = Server.AcceptTcpClient();
            Console.WriteLine("Verbindung hergestellt");

            Stream MessageStream = Client.GetStream();

            while (true)
            {
                byte[] message = new byte[4096];
                int bytesRead;
                bytesRead = MessageStream.Read(message, 0, 4096);

                if (bytesRead == 0)
                {

                    break;
                }

                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine(encoder.GetString(message, 0, bytesRead));

            }
        }
        void Stop()
        {
            isRunning = false;
        }
    }
}
