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
    public class MessageBox
    {
        string Title;
        public MessageBox(string Title)
        {
            this.Title = Title;
        }
        public async void e(string Text) // 实现使用MessageDialog控件实现的简单消息框
        {
            var dialog = new MessageDialog(Text, Title); // 设置消息框
            dialog.Commands.Add(new UICommand("知道了")); // 添加按钮
            await dialog.ShowAsync();                       // 显示
        }
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
