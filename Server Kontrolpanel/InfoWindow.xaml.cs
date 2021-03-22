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
using System.Windows.Shapes;
using System.Threading;

namespace Server_Kontrolpanel
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {

        SshClient client2 = new SshClient("45.76.43.221", "root", "j}7E(Ma38tMg8_ux");
        SshClient client3 = new SshClient("45.32.232.37", "root", "!Tz53@_BJ(RCdXk@");

        public string Ip;
        public string UserName;
        public string Password;
        public InfoWindow(string ip, string userName, string password)
        {
            InitializeComponent();

            Ip = ip;
            UserName = userName;
            Password = password;

            Thread thread = new Thread(info1);
            thread.IsBackground = true;
            thread.Start();
        }

        public void info1()
        {
            while (true)
            {
                using (var client = new SshClient(Ip, 22, UserName, Password))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            Dispatcher.Invoke(() => process.Items.Clear());
                            SshCommand sc = client.CreateCommand("ps -f");
                            SshCommand rr = client.CreateCommand("hostname");
                            SshCommand upTime = client.CreateCommand("uptime -p");
                            SshCommand ram = client.CreateCommand("echo $(($(getconf _PHYS_PAGES) * $(getconf PAGE_SIZE) / (1024 * 1024)))");
                            SshCommand disk = client.CreateCommand("df -h | grep '/dev/vda1' | awk '{print $3}' | sed 's/G/ GB/'");
                            SshCommand cpu = client.CreateCommand("top -b -n 1 -d 0.2 | tail -1 | awk '{print $9}'");



                            sc.Execute();
                            rr.Execute();
                            upTime.Execute();
                            ram.Execute();
                            disk.Execute();
                            cpu.Execute();
                            Dispatcher.Invoke(() => servername.Content = rr.Result);
                            Dispatcher.Invoke(() => uptime.Content = upTime.Result);
                            Dispatcher.Invoke(() => Cpu.Content = cpu.Result);

                            Dispatcher.Invoke(() => Ram.Content = ram.Result);
                            Dispatcher.Invoke(() => Disk.Content = disk.Result);
                            Dispatcher.Invoke(() => process.Items.Add(sc.Result));

                        }
                        client.Disconnect();
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {

                        servername.Content = "false";
                    }

                }
            }
        }



    }

}
