using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private IPAddress serverIP;
        private int serverPort;

        public Client(string ipaddress, string port)
        {
            
            this.serverIP = IPAddress.Parse(ipaddress);
            this.serverPort = int.Parse(port);
            InitializeComponent();

            // Start the Client
            Start();
        }

        void Start()
        {
            TcpClient Client = new TcpClient();
            Client.Connect(serverIP, serverPort);
            Stream MessageStream = Client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            while (true)
            {
                string nachricht = Console.ReadLine();
                byte[] buffer = encoder.GetBytes(nachricht);

                MessageStream.Write(buffer, 0, buffer.Length);
                MessageStream.Flush();

            }
        }
        void Stop()
        {

        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
