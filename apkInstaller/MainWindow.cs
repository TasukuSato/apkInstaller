using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;
using System.Net;

namespace apkInstaller
{
    public partial class MainWindow : Form
    {
        const string AdbPath = "./adb/adb.exe";
        AdbClient adbClient;

        public MainWindow()
        {
            InitializeComponent();

            StartAdbServer();

            UpdateApkList();
        }


        void UpdateApkList()
        {
            apkListView.Items.Clear();

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c dir /b");
            processStartInfo.WorkingDirectory = "./apk";
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;

            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            Process process = Process.Start(processStartInfo);

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            string[] files = output.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            
            for (int i = 0; i < files.Length - 1; i++)
            {
                ListViewItem item = new ListViewItem(files[i], i);
                ListViewSubItem defaultSubItem = new ListViewSubItem();
                defaultSubItem.Text = "未インストール";
                defaultSubItem.BackColor = Color.Red;
                item.SubItems.Add(defaultSubItem);
                apkListView.Items.Add(item);
            }

            process.Close();
        }

        void StartAdbServer()
        {
            adbClient = new AdbClient();
            var server = new AdbServer();
            server.StartServer(AdbPath, restartServerIfNewer: false);

            var adbMonitor = new DeviceMonitor(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
            adbMonitor.DeviceConnected += OnDeviceConnected;
            adbMonitor.DeviceDisconnected += OnDeviceDisconnected;
            adbMonitor.Start();
        }

        void OnDeviceConnected(object sender, DeviceDataEventArgs e)
        {
            RunOnUiThread(() =>
            {
                AddLog($"デバイスが接続されました:{e.Device.Serial}");
            });
        }

        void OnDeviceDisconnected(object sender, DeviceDataEventArgs e)
        {
            RunOnUiThread(() =>
            {
                AddLog($"デバイスの接続が解除されました:{e.Device.Serial}");
            });
        }

        async void StartInstallApk()
        {
            var devices = adbClient.GetDevices();
            if (devices.Count == 0)
            {
                //端末を接続してくださいというエラーを出す
                AddErrorLog("端末が接続されていません");
                return;
            } else if (devices.Count > 1)
            {
                //複数台の端末が接続されていますというエラーをだす
                AddErrorLog("複数の端末が接続されています");
                return;
            }

            var device = devices.First();
            var pm = new PackageManager(adbClient, device);
            for(int i = 0; i < apkListView.Items.Count; i++)
            {
                apkListView.Items[i].SubItems[1].Text = "インストール中";

                var apkName = apkListView.Items[i].Text;
                await Task.Run(() =>
                {
                    try
                    {
                        pm.InstallPackage($"./apk/{apkName}", true);
                    }
                    catch (Exception e)
                    {
                        RunOnUiThread(() =>
                        {
                            apkListView.Items[i].SubItems[1].Text = "インストール失敗";
                            apkListView.Items[i].BackColor = Color.Red;

                            AddErrorLog(e.Message);
                        });
                        return;
                    }

                    RunOnUiThread(() =>
                    {
                        apkListView.Items[i].SubItems[1].Text = "インストール済み";
                        apkListView.Items[i].BackColor = Color.LightGreen;
                    });
                });
            }
        }

        void AddLog(string message)
        {
            LogText.Items.Insert(0, new ListViewItem(message));
        }

        void AddErrorLog(string message)
        {
            ListViewItem logItem = new ListViewItem(message);
            logItem.ForeColor = Color.Red;
            LogText.Items.Add(logItem);
        }

        void UpdateListButton_Click(object sender, EventArgs e)
        {
            UpdateApkList();
        }

        void InstallButton_Click(object sender, EventArgs e)
        {
            StartInstallApk();
        }

        void RunOnUiThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => { action(); }));
            } else
            {
                action();
            }
        }
    }
}
