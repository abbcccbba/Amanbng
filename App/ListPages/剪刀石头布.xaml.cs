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
using System.Diagnostics;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.ListPages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 剪刀石头布 : Page
    {
        string selectedOption = ""; // 用于储存用户通过下拉选择框选择的内容
        short AICH; // 创建一个名为AICH的int类型随机数，用于为AI的选择
        short mode;

        public 剪刀石头布()
        {
            this.InitializeComponent();
            AICH = (short)new AppRuntime.Rand(0, 2).GetValue();
        }
        /// <summary>
        /// 打开消息框让用户选择难道并执行响应的代码
        /// </summary>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            /* 对话框控件定义 */
            ComboBox difficulty = new ComboBox() { PlaceholderText = "在这里选择" };
            List<string> items = new List<string> // 定义了下拉选择框里的内容（列表）
            {
                "简单",
                "普通",
                "困难"
            };
            foreach (string item in items) // 将刚刚定义的内容写入到下拉选择框里
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

                    if (selectedOption == "简单") 
                    {

                    }
                        
                    if (selectedOption == "普通") 
                    {
                        switch(AICH)
                        {
                            case 0:
                                x1.IsEnabled = false;
                                x2.IsEnabled = false;
                                break;
                            case 1:
                                x2.IsEnabled= false;
                                x3.IsEnabled = false; 
                                break;
                            case 2:
                                x1.IsEnabled= false;
                                x3.IsEnabled= false;
                                break;
                        }
                    }
                        
                    if (selectedOption == "困难") 
                    {
                    
                    }
                        
                }
            };
            UIElement[] Kongs = // 定义了消息框里都有啥。difficulty 就是那个下拉选择框
            {
                new TextBlock() { Text = "请选择你的难度系数"} ,
                difficulty
            };
            Kongs = await new MessageBox("我们需要一些信息").m("下一步", Kongs); // 显示消息框
            /* 为如果AI做出的不同选择写相应的代码 */
            switch (AICH)
            {
                case 0: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetJIANDAO.PNG")); break;
                case 1: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetSHITOU.PNG")); break;
                case 2: AIng.Source = new BitmapImage(new Uri("ms-appx:///Assets/SetBU.PNG")); break;
            }
            AiText.Text = "已就绪";
            PlayerText.Text = "正在选择";
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
        /// <summary>
        /// 当用户选择石头时执行
        /// </summary>
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
        /// <summary>
        /// 当用户选择布时执行
        /// </summary>
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
