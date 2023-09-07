using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using AppClasses;
using Windows.Media.Playback;
using Windows.Devices.Lights;
using System.Threading.Tasks;
// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //AppClasses.dt.SetWindowSize(853, 480); // 设置窗口大小
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(853, 480));
            ApplicationView.GetForCurrentView().TryResizeView(new Size(853, 480));
            VarFile();
            ToLogin();
        }
        private async void VarFile()
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile configFile = await localFolder.GetFileAsync("One.iso");
                if(await FileIO.ReadTextAsync(configFile) != "2bNe3kw")
                    Process.GetCurrentProcess().Kill();
            }
            catch (System.IO.IOException)
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile configFile = await localFolder.CreateFileAsync("One.iso", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(configFile, "2bNe3kw");
                IsOne();
            }
        }
        private async void ToLogin()
        {
            await Task.Delay(20);
            Frame.Navigate(typeof(Login));
        }
        private void IsOne()
        {
            textBlock.Text = "正在为初次打开进行准备工作";
            Mainringing.IsActive = true;
            /*这里写当应用初次打开时的处理代码*/

         }
    }
}
