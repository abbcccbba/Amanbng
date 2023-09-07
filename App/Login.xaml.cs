using AppClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        } 
        private void StartForm_Login(object sender, RoutedEventArgs e)
        {
            if (Account_TextBox.Text == "DeveloperTest") // 允许使用 DeveloperTest 来进行登入。关键是我没有服务器，所以这个登入功能真就像个摆设
                this.Frame.Navigate(typeof(MainPageMOM));
            else
                new MessageBox("Error :(").e("发生了什么？一个致命的错误。");
        }

        private void StartForm_New(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPageMOM));
        }

        private void Play_Yuanshen(object sender, RoutedEventArgs e)
        {
            // 原神，启动！！！
            string mediaPath = "ms-appx:///Assets/iiilab_video_2.mp4";
            new PlayM(mediaPath).V();
            //Frame.Navigate(typeof(ListWindows.PlayYuanshen), mediaPath);
        }

        private async void LoginT_WindowsHello(object sender, RoutedEventArgs e)
        {
            if (await AppRuntime.Idt.WindowsHello("验证用户登入"))
                Frame.Navigate(typeof(MainPageMOM));
            else
                new MessageBox("错误").e("用户终止了请求");
        }
    }
}
