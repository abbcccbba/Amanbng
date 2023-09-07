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
    public sealed partial class 身高计算器 : Page
    {
        public 身高计算器()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShowValue.Visibility = Visibility.Collapsed; // 初始化不显示结果
        }
        private async void start(object sender, RoutedEventArgs e)
        {
            /*代码是chatgpt写的就别问看不看得懂了*/
            ShowValue.Visibility = Visibility.Collapsed;
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
            ShowValue.Visibility = Visibility.Visible;
            ShowValue.Text = "你的身高是：" + StPut.Text;
        }
    }
}
