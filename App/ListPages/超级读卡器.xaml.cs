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

//using Windows.Media.Playback;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 超级读卡器 : Page
    {
        public 超级读卡器()
        {
            this.InitializeComponent();
            listN1_kaPin.Visibility = Visibility.Collapsed;
        }

        private void ListN1_start(object sender, RoutedEventArgs e)
        {
            /* 
             该函数的作用是播放声音，并显示隐藏的文字
             播放声音：这个就不必过多介绍了
             显示文字：实际上文字已经在xaml设计器里显示了，但是在超级读卡器类的构造函数里设为了隐藏值，但按钮触发时，取消隐藏
             */
            listN1_kaPin.Visibility = Visibility.Visible;
            new PlayM("ms-appx:///Assets/N1.mp3").A();
        }
    }
}
