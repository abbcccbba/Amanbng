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

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 时间查看器 : Page
    {
        public 时间查看器()
        {
            this.InitializeComponent();
        }
        private void listN3chu_Lanu(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selIfsr = selectedItem.Content.ToString();
                /* 多语言功能 */
                if(selIfsr == "中文（简体）")
                {
                    N3_MainText.Text = "时间查看器";
                    N3_MainButt.Content = "查看时间";
                }
                if(selIfsr == "English")
                {
                    N3_MainText.Text = "Time Viewer";
                    N3_MainButt.Content = "check time";
                }
                if(selIfsr == "日本語")
                {
                    N3_MainText.Text = "タイムビューア";
                    N3_MainButt.Content = "時間を確認する";
                }
                if(selIfsr == "한국인")
                {
                    N3_MainText.Text = "시간 뷰어";
                    N3_MainButt.Content = "시간 확인";
                }
            }
        }

        private void N3_MainButt_ShowTime(object sender, RoutedEventArgs e) // 垃圾命名懒得改了
        {
            string url = "https://www.baidu.com/s?wd=%E7%8E%B0%E5%9C%A8%E5%87%A0%E7%82%B9%E4%BA%86";
            new startLinker(url); //  startLinker 类负责打开一个链接，因为他是一个类，所以代码前面要加上new
        }
    }
}
