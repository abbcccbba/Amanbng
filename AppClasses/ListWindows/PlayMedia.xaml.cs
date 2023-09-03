using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace AppClasses.ListWindows
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PlayMedia : Page
    {
        public PlayMedia()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode(); // 请求全屏 *因为默认就是以全屏模式播放的
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MediaXAML.Source = new Uri(e.Parameter as string); // 取得媒体文件路径并写入控件
            MediaXAML.Play(); //播放
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e) // 播放完毕后执行
        {
            /*视频结束时退出全屏模式并关闭页面*/
            var view = ApplicationView.GetForCurrentView();
            view.ExitFullScreenMode();

            //Frame frame = Window.Current.Content as Frame;
            Frame.GoBack();
        }
    }
}
