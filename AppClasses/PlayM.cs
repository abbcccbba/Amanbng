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
    /// <summary>
    /// 提供了一个简单的播放音频或视频的方法
    /// </summary>
    public class PlayM
    {
        string mediaPath;
        /// <summary>
        /// 使用前设置媒体路径
        /// </summary>
        /// <param name="MediaPath">媒体路径（string）</param>
        public PlayM(string MediaPath) 
        {
            mediaPath = MediaPath;
        }
        /// <summary>
        /// 将会以全屏模式播放视频
        /// </summary>
        public void V() // 播放视频
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(ListWindows.PlayMedia), mediaPath);

            Window.Current.Content = frame;
            Window.Current.Activate();
        }
        /// <summary>
        /// 将会后台静默播放音频
        /// </summary>
        public async void A() // 播放音乐
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            var audioFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(mediaPath));
            mediaPlayer.Source = MediaSource.CreateFromStorageFile(audioFile);
            mediaPlayer.Play();
        }
    }
}
