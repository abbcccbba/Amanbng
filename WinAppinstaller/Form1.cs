using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppinstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void installing(object sender, EventArgs e)
        {
            // 文件释放
            byte[] Save = AppData.App;
            string tempFolderPath = Path.Combine(Path.GetTempPath(), "installprogramname.msixbundle");

            using (FileStream fsObj = new FileStream(tempFolderPath, FileMode.CreateNew))
            {
                await fsObj.WriteAsync(Save, 0, Save.Length);
                fsObj.Flush();
            }

            // PowerShell 安装包
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new Process
            {
                StartInfo = psi
            };

            process.Start();
            string installCommand = "Add-AppxPackage \"" + tempFolderPath + "\"";
            process.StandardInput.WriteLine(installCommand);

            // 异步读取标准输出
            Task<string> outputTask = process.StandardOutput.ReadToEndAsync();
            string output = await outputTask;
            Console.WriteLine(output);

            process.WaitForExit();
            process.Close();

            MessageBox.Show("已完成安装");
        }
    }
}
