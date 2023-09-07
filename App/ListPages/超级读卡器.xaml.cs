using AppClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App.ListPages
{
    public sealed partial class 超级读卡器 : Page
    {
        public 超级读卡器()
        {
            this.InitializeComponent();     
        }
        /// <summary>
        /// 设置点击按钮后显示的问题默认显示属性为隐藏
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShowKa.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 当用户点击“将卡片放在按钮上面后点击开始读卡”时里面的代码开始执行
        /// </summary>
        private void start(object sender, RoutedEventArgs e)
        {
            ShowKa.Visibility = Visibility.Visible;
            new PlayM("ms-appx:///Assets/N1.mp3").A();
        }
    }
}
