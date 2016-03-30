using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client client;
        private Server server;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStartClient_Click(object sender, RoutedEventArgs e)
        {
            client = new Client(tbClientIP.Text, tbClientPort.Text);
        }

        private void bStartServer_Click(object sender, RoutedEventArgs e)
        {
            server = new Server(tbServerIP.Text, tbServerPort.Text);
            
            while(server.isRunning)
            {
                lServerState.Content = "true";
            }
            
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
