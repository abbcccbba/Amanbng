using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppClasses
{
    /// <summary>
    /// 提供了一个简单对话框
    /// </summary>
    public class MessageBox
    {
        string Title;
        /// <summary>
        /// 设置对话框标题
        /// </summary>
        /// <param name="Title">标题</param>
        public MessageBox(string Title)
        {
            this.Title = Title;
        }
        /// <summary>
        /// 以简单模式弹对话框
        /// </summary>
        /// <param name="Text">对话框内容</param>
        public async void e(string Text) // 实现使用MessageDialog控件实现的简单消息框
        {
            var dialog = new MessageDialog(Text, Title); // 设置消息框
            dialog.Commands.Add(new UICommand("知道了")); // 添加按钮
            await dialog.ShowAsync();                       // 显示
        }
        /// <summary>
        /// 以复杂模式弹对话框
        /// </summary>
        /// <param name="ButtonText">确认按钮文本</param>
        /// <param name="kongs">控件列表</param>
        /// <returns>原控件列表用于读取值</returns>
        public async Task<UIElement[]> m(string ButtonText,UIElement[] kongs)
        {
            UIElement[] ConKongs = kongs;
            StackPanel Dias = new StackPanel();
            foreach (UIElement IKongs in ConKongs) Dias.Children.Add(IKongs); // 将内容放到StackPanel备用
            ContentDialog myDialog = new ContentDialog()
            {
                Title = this.Title,
                Content = Dias,
                PrimaryButtonText = ButtonText
            };
            await myDialog.ShowAsync();
            return ConKongs;
        }
    }
}
