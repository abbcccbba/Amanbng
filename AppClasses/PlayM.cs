using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using System.ComponentModel.DataAnnotations;
using System;

namespace AppClasses
{ 
    /*
     PlayM类能让开发者简单的实现视频播放以及音频播放的功能
    构造函数的传入参数是媒体文件地址
    V、A分别代表以视频模式播放和以音乐模式播放
    代码演示：
    new PlayM("ms-appx:///Assets/MyMusic.mp3").A();
     */
    public class PlayM
    {
        string mediaPath;
        public PlayM(string MediaPath) 
        {
            mediaPath = MediaPath;
        }
        public void V() // 播放视频
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(ListWindows.PlayMedia), mediaPath);

            Window.Current.Content = frame;
            Window.Current.Activate();
        }
        public async void A() // 播放音乐
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            var audioFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(mediaPath));
            mediaPlayer.Source = MediaSource.CreateFromStorageFile(audioFile);
            mediaPlayer.Play();
        }
    }
}
