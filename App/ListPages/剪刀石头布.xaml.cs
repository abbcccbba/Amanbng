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

using AppClasses;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 剪刀石头布 : Page
    {
        string selectedOption = ""; // 用于储存用户通过下拉选择框选择的内容
        int AICH = new AppRuntime.Rand(0,2).GetValue();
        public 剪刀石头布()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            /* 对话框控件定义 */
            ComboBox difficulty = new ComboBox() { PlaceholderText = "在这里选择" };
            List<string> items = new List<string>
            {
                "简单",
                "普通",
                "困难"
            };
            foreach (string item in items)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item;
                difficulty.Items.Add(comboBoxItem);
            }
            
            difficulty.SelectionChanged += (sender, args) => // 事件相关代码 *chatgpt写的
            {
                ComboBox comboBox = sender as ComboBox;
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                
                if (selectedItem != null)
                {
                    selectedOption = selectedItem.Content.ToString();

                    // 根据不同的选项执行不同的函数
                    if (selectedOption == "简单") { ut1(); }
                        
                    if (selectedOption == "普通") { ut2(); }
                        
                    if (selectedOption == "困难") { ut3(); }
                        
                }
                else new MessageBox("Error :(").e("请选择一个值");
            };
            UIElement[] Kongs =
            {
                new TextBlock() { Text = "请选择你的难度系数"} ,
                difficulty
            };
            Kongs = await new MessageBox("我们需要一些信息").m("下一步", Kongs);
            await Task.Delay(3000); // 延迟显示AI选择，让玩家错以为真的在做计算
            switch (AICH)
            {
                case 0: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG")); break;
                case 1: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG")); break;
                case 2: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG")); break;
            }
            AiText.Text = "已就绪";
            PlayerText.Text = "正在选择";
        }
        private void ut1()
        {
            // 执行与选项 "简单" 相关的操作
            // 如果选择简单不会执行任何限制代码，因为这是最简单的难度，没有限制
        }

        private void ut2()
        {
            // 执行与选项 "普通" 相关的操作
            switch (AICH)
            {
                case 0: // 如果AI出了剪刀 那就不允许玩家出石头和剪刀
                    {
                        x1.IsEnabled = false;
                        x2.IsEnabled = false;
                        break;
                    }
                case 1: // 如果AI出了石头 那就不允许玩家出石头和布
                    {
                        x2.IsEnabled = false;
                        x3.IsEnabled = false;
                        break;
                    }
                case 2: // 如果AI出了布 那就不允许玩家出剪刀和布
                    {
                        x1.IsEnabled = false;
                        x3.IsEnabled = false;
                        break;
                    }
            }
        }

        private async void ut3()
        {
            // 执行与选项 "困难" 相关的操作
            x1.IsEnabled = false;
            x2.IsEnabled = false;
            x3.IsEnabled = false;
            await Task.Delay(3000);
            new MessageBox("结果").e("不好意思你输了");
            new MessageBox("警告").e("由于难度限制，你无法选择任何内容。将自动执行失败代码");
        }

        private void Set_JianDao(object sender, RoutedEventArgs e)
        {
            PLayeng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG"));
            PlayerText.Text = "已就绪";
            switch (AICH)
            {
                case 0:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG"));
                        new MessageBox("结果").e("平局");
                        break;
                    }
                case 1:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG"));
                        new MessageBox("结果").e("你输了");
                        break;
                    }
                case 2:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG"));
                        new MessageBox("结果").e("你赢了");
                        break;
                    }
            }
        }

        private void Set_ShiTou(object sender, RoutedEventArgs e)
        {
            PLayeng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG"));
            PlayerText.Text = "已就绪";
            switch (AICH)
            {
                case 0:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG"));
                        new MessageBox("结果").e("你赢了");
                        break;
                    }
                case 1:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG"));
                        new MessageBox("结果").e("平局");
                        break;
                    }
                case 2:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG"));
                        new MessageBox("结果").e("你输了");
                        break;
                    }
            }
        }

        private void Set_Bu(object sender, RoutedEventArgs e)
        {
            PLayeng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG"));
            PlayerText.Text = "已就绪";
            switch (AICH)
            {
                case 0:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG"));
                        new MessageBox("结果").e("你输了");
                        break;
                    }
                case 1:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG"));
                        new MessageBox("结果").e("你赢了");
                        break;
                    }
                case 2:
                    {
                        AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG"));
                        new MessageBox("结果").e("平局");
                        break;
                    }
            }
        }
    }
}
