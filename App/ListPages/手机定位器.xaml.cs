using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class 手机定位器 : Page
    {

        public 手机定位器()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 初始化一些东西
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShowRingtime.Visibility = Visibility.Collapsed; // 设置默认结果标签为隐藏
            MainPic.Visibility = Visibility.Collapsed; // 这是隐藏图片框
        }
        /// <summary>
        /// 当用户点击“立即尝试！”时执行
        /// </summary>
        private async void start(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox(); // 一个文本框 ，在对话框里要求用户输入手机位置的文本框就是这个
            CheckBox checkBox = new CheckBox() { Content = "启用高级查找" }; // 多选框，看文字你就知道
            UIElement[] Kongs = { // 控件列表，把之前的东西全部赛道里面 
                new TextBlock {Text = "手机的位置" },
                textBox,
                checkBox
            };
            Kongs = await new MessageBox("我们需要一些信息").m("下一步", Kongs);
            /*这两行代码算是把构造函数里的复制粘贴到这里了，这么干是为了不出bug*/
            ShowRingtime.Visibility = Visibility.Collapsed;
            MainPic.Visibility = Visibility.Collapsed;
            ShowRingtime.Text = "正在定位"; // 打印初始文字，告诉用户信息
            /* 剩下的几行代码作用就是计时，具体怎么做到计时的别问我，这部分chatgpt写的 */
            TimeSpan totalTime = TimeSpan.FromSeconds(5); 
            TimeSpan interval = TimeSpan.FromMilliseconds(1000); 
            DateTime startTime;
            ShowRingtime.Visibility = Visibility.Visible; 
            ring.IsActive = true; 

            startTime = DateTime.Now; 

            while (DateTime.Now - startTime < totalTime)
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                TimeSpan remainingTime = totalTime - elapsed;

                await Task.Delay(interval); 
            }
            
            ring.IsActive = false; // 结束等待
 
            ShowRingtime.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 10, 213, 9)); // 改个颜色，告诉用户已完成
            /* 接下来一些简单的判断这个函数就结束了  */
            if (checkBox.IsChecked == true)
            {
                MainPic.Visibility = Visibility.Visible;
                ShowRingtime.Text = "已查找到 在：";
            }
            else ShowRingtime.Text = "已查找到 在：" + textBox.Text;
        }
    }
}
