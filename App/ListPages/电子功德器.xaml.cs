using AppClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 电子功德器 : Page
    {
        private int ZC_ging = 0;
        public 电子功德器()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GD_str.Visibility = Visibility.Collapsed;
        }
        private async void GongDe(object sender, RoutedEventArgs e)
        {
            ZC_ging++;
            GD_int.Text = "功德数：" + ZC_ging.ToString();
            new PlayM("ms-appx:///Assets/NBm.mp3").A();
            GD_str.Visibility = Visibility.Visible;
            await Task.Delay(300);
            GD_str.Visibility = Visibility.Collapsed;
            
        }

        private void CR(object sender, TappedRoutedEventArgs e)
        {
            ZC_ging = 0;
            GD_int.Text = "功德数：0（已重置）";
        }
    }
}
