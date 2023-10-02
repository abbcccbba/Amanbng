using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
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

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(853, 480));
            ApplicationView.GetForCurrentView().TryResizeView(new Windows.Foundation.Size(853, 480));
            

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Task.Run(() => { 
                new AppClasses.PlayM("ms-appx:///Assets//asF/music.mp3").A(); 
            });
        }

        private async void Button_Login(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TextBox Account = new TextBox() 
            { 
                Text = "dingdang@outlook.com"
                // 默认登入时账号
            };
            
            UIElement[] Kongs =
            {
                new TextBlock() {Text = "请输入你的账号"},
                Account
            };
            Kongs = await new AppClasses.MessageBox("继续你的登入").m("下一步", Kongs);
            if (Account.Text != "dingdang@outlook.com")
                new AppClasses.MessageBox("错误").e("我们找不到你的账号");
            else
            {
                PasswordBox Password = new PasswordBox() {PasswordChar='#'.ToString() };
                UIElement[] Kongs_P =
                {
                    new TextBlock() {Text = "请输入你的密码" },
                    Password
                };
                Kongs_P = await new AppClasses.MessageBox("继续你的登入").m("下一步", Kongs_P);
                Frame.Navigate(typeof(MainPageMOM));
            }
        }
    }
}
