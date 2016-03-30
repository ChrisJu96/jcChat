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
        public string NameOfParticipant;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStartClient_Click(object sender, RoutedEventArgs e)
        {
            NameOfParticipant = tbName.Text;
            client = new Client();
            client.Show();
            client.lbParticipants.Items.Add(NameOfParticipant);
        }


        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
