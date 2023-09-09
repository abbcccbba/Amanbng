using AppClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.ListPages
{
    public sealed partial class 电子功德器 : Page
    {
        private int ZC_ging = 0; // 这个是功德数，默认为0，初始为0，重置后为0
        Thread StartThread;      // 这个是线程对象，用于播放背景音乐。定义在这里是因为有多个方法需要使用
        public 电子功德器()
        {
            this.InitializeComponent();
            this.ReturnFrame.Navigated += (sender, e) =>
            {
                StartThread.Abort();
            };
        }  
        /// <summary>
        /// 初始化一些东西
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GD_str.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 当用户点击 “敲击木鱼”时执行
        /// </summary>
        private async void GongDe(object sender, RoutedEventArgs e)
        {
            ZC_ging++;
            GD_int.Text = "功德数：" + ZC_ging.ToString();
            new PlayM("ms-appx:///Assets/NBm.mp3").A();
            GD_str.Visibility = Visibility.Visible;
            await Task.Delay(300);
            GD_str.Visibility = Visibility.Collapsed;
            
        }
        /// <summary>
        /// 当用户电子木鱼图片时，执行：重置功德数
        /// </summary>
        private void CR(object sender, TappedRoutedEventArgs e)
        {
            ZC_ging = 0;
            GD_int.Text = "功德数：0（已重置）";
        }
    }
}
