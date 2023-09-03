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
            // 根据操作系统位数选择要使用的数据
            byte[] Save;

            //if (Environment.Is64BitOperatingSystem)
            //{
            //    Save = AppData.x64;
            //}
            //else
            //{
            //    Save = AppData.x86;
            //}

            Save = AppData.App;

            // 文件路径
            string filePath = Path.Combine(Path.GetTempPath(), "nbtools.msixbundle");

            // 异步执行操作
            await Task.Run(() =>
            {
                // 文件释放
                using (FileStream fsObj = new FileStream(filePath, FileMode.Create))
                {
                    fsObj.Write(Save, 0, Save.Length);
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
                string installCommand = "Add-AppxPackage \"" + filePath + "\"";
                process.StandardInput.WriteLine(installCommand);

                // 异步读取标准输出
                Task<string> outputTask = process.StandardOutput.ReadToEndAsync();
                string output = outputTask.Result; // 使用 .Result 阻塞等待结果

                process.WaitForExit();
                process.Close();

                // 删除文件
                File.Delete(filePath);
              
            });
        }
    }
}
