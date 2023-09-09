using AppClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Management;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App
{
    public sealed partial class MainPageMOM : Page
    {
        public MainPageMOM()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MediaPage.Play();
            MediaPage.Stretch = Stretch.UniformToFill;
        }
        /* 懂得都懂 */
        private void Tp_N1(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.超级读卡器));
        }

        private void Tp_N2(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.身高计算器));
        }

        private void Tp_N3(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.时间查看器));
        }

        private void Tp_N4(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.手机定位器));
        }

        private void Tp_N5(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.字符拼接器));
        }

        private void Tp_N6(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.剪刀石头布));
        }
        private void Tp_N7(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ListPages.电子功德器));
        }
    }   
}
