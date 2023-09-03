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

using AppClasses;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 身高计算器 : Page
    {
        public 身高计算器()
        {
            this.InitializeComponent();
            listN2_kaPin.Visibility = Visibility.Collapsed;
        }
        private async void listN2_startcom(object sender, RoutedEventArgs e)
        {
            /*代码是chatgpt写的就别问看不看得懂了*/
            listN2_kaPin.Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Visible;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            TimeSpan taskDuration = TimeSpan.FromSeconds(3);
            DateTime startTime = DateTime.Now;

            while (DateTime.Now - startTime < taskDuration)
            {
                double progress = (DateTime.Now - startTime).TotalMilliseconds / taskDuration.TotalMilliseconds * 100;
                progressBar.Value = Math.Min(progress, 100);
                await Task.Delay(10); 
            }

            progressBar.Visibility = Visibility.Collapsed;
            listN2_kaPin.Visibility = Visibility.Visible;
            listN2_kaPin.Text = "你的身高是：" + StPut.Text;
        }
    }
}
