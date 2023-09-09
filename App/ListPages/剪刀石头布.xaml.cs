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
            Action m = () => { new MessageBox("错误").e("无法调用解除函数"); } ;
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

                    // 根据不同的选项执行不同的函数
                    if (selectedOption == "简单") { Action ut1 = () => { }; ut1(); m = async () =>
                    {
                        x1.IsEnabled = false;
                        x2.IsEnabled = false;
                        x3.IsEnabled = false;
                        await Task.Delay(3000); 
                        x1.IsEnabled = true;
                        x2.IsEnabled = true;
                        x3.IsEnabled = true;
                    };
                    }
                        
                    if (selectedOption == "普通") { Action ut2 = () => 
                    {
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
                    }; ut2(); m = async () =>
                    {
                        x1.IsEnabled = false;
                        x2.IsEnabled = false;
                        x3.IsEnabled = false;
                        await Task.Delay(3000); // 延迟显示AI选择，让玩家错以为真的在做计算
                        switch (AICH) {
                            case 0:
                                x3.IsEnabled = true;break;
                            case 1:
                                x1.IsEnabled = true;break;
                            case 2:
                                x2.IsEnabled = true;break;
                        }
                    };
                    }
                        
                    if (selectedOption == "困难") { Action  ut3 = async () => 
                    {
                        x1.IsEnabled = false;
                        x2.IsEnabled = false;
                        x3.IsEnabled = false;
                        await Task.Delay(3000); // 等待一会，让用户不要过早的遗憾
                                                // 禁用所有按钮并告诉用户你输了
                        new MessageBox("结果").e("不好意思你输了");
                        new MessageBox("警告").e("由于难度限制，你无法选择任何内容。将自动执行失败代码");
                    }; ut3(); }
                        
                }
                else new MessageBox("Error :(").e("请选择一个值");
            };
            UIElement[] Kongs = // 定义了消息框里都有啥。difficulty 就是那个下拉选择框
            {
                new TextBlock() { Text = "请选择你的难度系数"} ,
                difficulty
            };
            Kongs = await new MessageBox("我们需要一些信息").m("下一步", Kongs); // 显示消息框
            m();
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
