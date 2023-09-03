using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts.DataProvider;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace AppRuntime
{
    public sealed class Rand
    {
        Random start = new Random(ConData());
        private int Jr;
        public Rand()
        {
            Jr = start.Next();
        }
        public Rand(int min,int max) 
        {
            Random random = new Random(start.Next());
            Jr = random.Next(min, max + 1);               
        }
        public int GetValue()
        {
            return Jr;
        }
        public static int ConData()
        {
            int[] MyInts = Getdata();
            return MyInts[2]
                + MyInts[3]
                * 3
                - 17
                + (MyInts[0] + MyInts[1])
                + MyInts[2]
                - (MyInts[0] * 2)
                * 8
                / 2;
        }
        private static int[] Getdata()
        {
            //设备名称
            var deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
            string deviceName = deviceInfo.FriendlyName;
            char[] deviceNameChars = deviceName.ToCharArray();

            // 网络连接状态
            var internetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
            bool isConnected = (internetConnectionProfile != null && internetConnectionProfile.GetNetworkConnectivityLevel() == Windows.Networking.Connectivity.NetworkConnectivityLevel.InternetAccess);

            //深色模式状态
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            bool isDarkMode = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background).Equals(Windows.UI.Colors.Black);

            //音量值
            var mediaPlayer = new Windows.Media.Playback.MediaPlayer();
            int volume = (int)(mediaPlayer.Volume * 100);

            //处理为int
            int[] RetVel = new int[4];
            foreach (char cr in deviceNameChars)
            {
                bool isChinese = (cr >= 0x4e00 && cr <= 0x9fff);
                bool isLetter = char.IsLetter(cr);
                bool isDigit = char.IsDigit(cr);
                if (isChinese)
                {
                    if (DateTime.Now.Minute < 30)
                        RetVel[0] = 1;
                    else
                        RetVel[0] = 2;
                }
                else if (isLetter)
                {
                    if (DateTime.Now.Minute < 30)
                        RetVel[0] = 3;
                    else
                        RetVel[0] = 4;
                }
                else if (isDigit)
                {
                    if (DateTime.Now.Minute < 30)
                        RetVel[0] = 5;
                    else
                        RetVel[0] = 6;
                }
                else { RetVel[0] = 7; }
            }
            if (DateTime.Now.Minute < 12)
            {
                if (isConnected)
                    RetVel[1] = 1;
                else
                    RetVel[1] = 2;
                if (isDarkMode)
                    RetVel[2] = 1;
                else
                    RetVel[2] = 2;
            }
            else if (DateTime.Now.Minute < 24)
            {
                if (isConnected) RetVel[1] = 3;
                else RetVel[1] = 4;
                if (isDarkMode) RetVel[2] = 3;
                else RetVel[2] = 4;
            }
            else {
                if (isConnected) RetVel[1] = 5;
                else RetVel[1] = 6;
                if (isDarkMode) RetVel[2] = 5;
                else RetVel[2] = 6;
            }
            RetVel[3] = volume;
            return RetVel;
        }
    }
}
