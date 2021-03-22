using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        SshClient client1 = new SshClient("95.179.187.146", "root", "$s8PtAa)uEZW{H[2");
        SshClient client2 = new SshClient("45.76.43.221", "root", "j}7E(Ma38tMg8_ux");
        SshClient client3 = new SshClient("45.32.232.37", "root", "!Tz53@_BJ(RCdXk@");
        public MainWindow()
        {
            InitializeComponent();

            

            client1.Connect();
            client2.Connect();
            client3.Connect();
            try
            {
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
            catch (Exception)
            {

                Status3.Fill = Brushes.Gray;
            }
            client1.Disconnect();
            client2.Disconnect();
            client3.Disconnect();
        }

        private void RunServer1()
        {
            InfoWindow rr = new InfoWindow("95.179.187.146", "root", "$s8PtAa)uEZW{H[2");
            rr.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void RunServer2()
        {
            InfoWindow rr = new InfoWindow("45.76.43.221", "root", "j}7E(Ma38tMg8_ux");
            rr.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void RunServer3()
        {
            InfoWindow rr = new InfoWindow("45.32.232.37", "root", "!Tz53@_BJ(RCdXk@");
            rr.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void Server1Reboot_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Server1Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client1.Connect();
                client1.Disconnect();
                Thread thread = new Thread(RunServer1);
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception)
            {
                Status1.Fill = Brushes.Red;
                MessageBox.Show("Lost connection...");
            }
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
            try
            {
                client2.Connect();
                client2.Disconnect();
                Thread thread = new Thread(RunServer2);
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception)
            {
                Status1.Fill = Brushes.Red;
                MessageBox.Show("Lost connection...");
            }
            
        }

        private void Server3Reboot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Server3Info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client3.Connect();
                client3.Disconnect();
                Thread thread = new Thread(RunServer3);
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception)
            {
                Status1.Fill = Brushes.Red;
                MessageBox.Show("Lost connection...");
            }
        }
    }
}
