using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Devices;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media;
using Windows.Media.Audio;
using Windows.Media.Effects;
using Windows.Media.Render;
using Windows.Media.Playback;
using AppClasses;

namespace AppClasses
{
    /*
     AppClasses命名空间提供了一些方便的开发者常用方法
    当然，也可以一个代码文件写一个类的。但还是那句话，懒得了
     */
    public class dt
    {
        /* dt类提供了一些，基本上程序里只调用过一次的函数与功能*/
        public static void SetWindowSize(double newWidth, double newHeight)
        { 
            //设置创建大小，不必多说了
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(newWidth, newHeight));
            ApplicationView.GetForCurrentView().TryResizeView(new Size(newWidth, newHeight));
        }
    }
    
    }
    
    public class startLinker
    {
        /*没什么好说的，就是打开链接，参数是链接的url，比如https://www.google.com*/
        public startLinker(string url) 
        {
            main(url);
        }
        private async void main(string url)
        {
            var uri = new Uri(url);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
