using Renci.SshNet;
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

namespace Server_Kontrolpanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SshClient client1 = new SshClient("95.179.187.146", "root", "$s8PtAa)uEZW{H[2");
            SshClient client2 = new SshClient("45.76.43.221", "root", "j}7E(Ma38tMg8_ux");
            SshClient client3 = new SshClient("45.32.232.37", "root", "!Tz53@_BJ(RCdXk@");
            client1.Connect();
            client2.Connect();
            client3.Connect();

            if (client1.IsConnected)
            {
                Status1.Fill = Brushes.Green;
            }
            if (client2.IsConnected)
            {
                Status2.Fill = Brushes.Green;
            }
            if (client3.IsConnected)
            {
                Status3.Fill = Brushes.Green;
            }
        }

        private void Server1Reboot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Server1Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Server2Reboot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new SshClient("95.179.187.146", "root", "$s8PtAa)uEZW{H[2");
                client.Connect();

                if (client.IsConnected)
                {
                    Status1.Fill = Brushes.Red;
                    client.RunCommand("reboot");
                    MessageBox.Show("Rebooting...");
                    Status1.Fill = Brushes.Green;
                    MessageBox.Show("Reboot complete");
                    client.Disconnect();

                }
                else
                {
                    Status1.Fill = Brushes.Red;
                    MessageBox.Show("Unable to reboot");
                }
            }

            catch
            {
            }
        }

        private void Server2Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Server3Reboot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Server3Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit1_Click(object sender, RoutedEventArgs e)
        {
            Edit1 edit = new Edit1();
            edit.Show();
        }

        private void Edit2_Click(object sender, RoutedEventArgs e)
        {
            Edit1 edit = new Edit1();
            edit.Show();
        }

        private void Edit3_Click(object sender, RoutedEventArgs e)
        {
            Edit1 edit = new Edit1();
            edit.Show();
        }
    }
}
