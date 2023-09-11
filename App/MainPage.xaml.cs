using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using AppClasses;
using Windows.Media.Playback;
using Windows.Devices.Lights;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Storage.Streams;
using System.Drawing;
// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板


/*
 '''
                  江城子 . 程序员之歌

              十年生死两茫茫，写程序，到天亮。
                  千行代码，Bug何处藏。
              纵使上线又怎样，朝令改，夕断肠。

              领导每天新想法，天天改，日日忙。
                  相顾无言，惟有泪千行。
              每晚灯火阑珊处，夜难寐，加班狂。

'''
 '''
                       _oo0oo_
                      o8888888o
                      88" . "88
                      (| -_- |)
                      0\  =  /0
                    ___/`---'\___
                  .' \\|     |// '.
                 / \\|||  :  |||// \
                / _||||| -:- |||||- \
               |   | \\\  - /// |   |
               | \_|  ''\---/''  |_/ |
               \  .-\__  '-'  ___/-. /
             ___'. .'  /--.--\  `. .'___
          ."" '<  `.___\_<|>_/___.' >' "".
         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
         \  \ `_.   \_ __\ /__ _/   .-` /  /
     =====`-.____`.___ \_____/___.-`___.-'=====
                       `=---='


     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

           佛祖保佑     永不宕机     永无BUG
'''
'''
          佛曰:  
                  写字楼里写字间，写字间里程序员；  
                  程序人员写程序，又拿程序换酒钱。  
                  酒醒只在网上坐，酒醉还来网下眠；  
                  酒醉酒醒日复日，网上网下年复年。  
                  但愿老死电脑间，不愿鞠躬老板前；  
                  奔驰宝马贵者趣，公交自行程序员。  
                  别人笑我忒疯癫，我笑自己命太贱；  
                  不见满街漂亮妹，哪个归得程序员？
'''
 */
namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //AppClasses.dt.SetWindowSize(853, 480); // 设置窗口大小
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(853, 480));
            ApplicationView.GetForCurrentView().TryResizeView(new Windows.Foundation.Size(853, 480)); 
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            VarFile();
        }

        private async void VarFile()
        {
            try
            {
                StorageFile configFile = await (ApplicationData.Current.LocalFolder).GetFileAsync("One.iso");
                if(await FileIO.ReadTextAsync(configFile) == "2bNe3kw")
                    Frame.Navigate(typeof(Login));
                else
                {
                    textBlock.Text = "无法完成验证";
                }
            }
            catch (System.IO.IOException)
            {
                StorageFile configFile = await (ApplicationData.Current.LocalFolder).CreateFileAsync("One.iso", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(configFile, "2bNe3kw");
                IsOne();
            }
        }
        private async void IsOne()
        {
            textBlock.Text = "正在为初次打开进行准备工作";
            Mainringing.IsActive = true;
            /*这里写当应用初次打开时的处理代码*/
            await Task.Delay(10000);
            Frame.Navigate(typeof(Login));
        }
    }
}
