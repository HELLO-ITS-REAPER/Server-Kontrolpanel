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

namespace Server_Kontrolpanel
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        SshClient client2 = new SshClient("45.76.43.221", "root", "j}7E(Ma38tMg8_ux");
        SshClient client3 = new SshClient("45.32.232.37", "root", "!Tz53@_BJ(RCdXk@");
        public Window1()
        {
            InitializeComponent();
        }

        public void info1()
        {
            using (var client = new SshClient("95.179.187.146",22, "root", "$s8PtAa)uEZW{H[2"))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        SshCommand sc = client.CreateCommand("ps -f");
                        SshCommand rr = client.CreateCommand("hostname");
                        SshCommand upTime = client.CreateCommand("uptime -p");
                        SshCommand ram = client.CreateCommand("echo $(($(getconf _PHYS_PAGES) * $(getconf PAGE_SIZE) / (1024 * 1024)))");
                        SshCommand disk = client.CreateCommand("df -h | grep '/dev/vda1' | awk '{print $3}' | sed 's/G/ GB/'");
                        SshCommand cpu = client.CreateCommand("top -b -n 2 -d 0.2 | tail -1 | awk '{print $9}'");



                        sc.Execute();
                        rr.Execute();
                        upTime.Execute();
                        ram.Execute();
                        disk.Execute();
                        cpu.Execute();
                        servername.Content = rr.Result;
                        uptime.Content = upTime.Result;
                        Cpu.Content = cpu.Result;
                        
                        Ram.Content = ram.Result;
                        Disk.Content = disk.Result;
                        process.Items.Add(sc.Result);

                    }
                }
                catch (Exception)
                {

                    servername.Content = "false";
                }

            }
            

        }


        public void info2()
        {
            using (var client = new SshClient("45.76.43.221", 22, "root", "j}7E(Ma38tMg8_ux"))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        SshCommand sc = client.CreateCommand("ps -f");
                        SshCommand rr = client.CreateCommand("hostname");
                        SshCommand upTime = client.CreateCommand("uptime -p");
                        SshCommand ram = client.CreateCommand("echo $(($(getconf _PHYS_PAGES) * $(getconf PAGE_SIZE) / (1024 * 1024)))");
                        SshCommand disk = client.CreateCommand("df -h | grep '/dev/vda1' | awk '{print $3}' | sed 's/G/ GB/'");
                        SshCommand cpu = client.CreateCommand("top -b -n 2 -d 0.2 | tail -1 | awk '{print $9}'");



                        sc.Execute();
                        rr.Execute();
                        upTime.Execute();
                        ram.Execute();
                        disk.Execute();
                        cpu.Execute();
                        servername.Content = rr.Result;
                        uptime.Content = upTime.Result;
                        Cpu.Content = cpu.Result;

                        Ram.Content = ram.Result;
                        Disk.Content = disk.Result;
                        process.Items.Add(sc.Result);

                    }
                }
                catch (Exception)
                {

                    servername.Content = "false";
                }

            }


        }

        public void info3()
        {
            using (var client = new SshClient("45.32.232.37", 22, "root", "!Tz53@_BJ(RCdXk@"))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        SshCommand sc = client.CreateCommand("ps -f");
                        SshCommand rr = client.CreateCommand("hostname");
                        SshCommand upTime = client.CreateCommand("uptime -p");
                        SshCommand ram = client.CreateCommand("echo $(($(getconf _PHYS_PAGES) * $(getconf PAGE_SIZE) / (1024 * 1024)))");
                        SshCommand disk = client.CreateCommand("df -h | grep '/dev/vda1' | awk '{print $3}' | sed 's/G/ GB/'");
                        SshCommand cpu = client.CreateCommand("top -b -n 2 -d 0.2 | tail -1 | awk '{print $9}'");



                        sc.Execute();
                        rr.Execute();
                        upTime.Execute();
                        ram.Execute();
                        disk.Execute();
                        cpu.Execute();
                        servername.Content = rr.Result;
                        uptime.Content = upTime.Result;
                        Cpu.Content = cpu.Result;

                        Ram.Content = ram.Result;
                        Disk.Content = disk.Result;
                        process.Items.Add(sc.Result);

                    }
                }
                catch (Exception)
                {

                    servername.Content = "false";
                }

            }


        }

    }

}
